using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerModel model;
    //public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        model = GetComponent<PlayerModel>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Thread();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            model.Move(horizontalInput);
        }
    }


    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            model.Jump();
        }
    }
    private bool IsGrounded()
    {
        Vector2 rayStart = new Vector2(transform.position.x, transform.position.y) + Vector2.up * -0.5f;

        // Ray를 Player의 하단에서 아래 방향으로 발사합니다.
        RaycastHit2D hitInfo = Physics2D.Raycast(rayStart, Vector2.down, 0.1f);
        
        if (hitInfo.collider == null) return false;

        return hitInfo.collider.CompareTag("Ground");
    }


    private void Thread()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            if (!model.connect)
            {
                ConnectThread();
            }
            else
            {
                DisConnectThread();
            }
        }
    }
    private void ConnectThread()
    {
        Vector2 dir = GetDirection();
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, dir, 5f, 1<< LayerMask.NameToLayer("Object"));
        if (rayHit.collider != null)
        {
            model.connect = true;
            model.connectedObject = rayHit.transform;
            switch (model.connectedObject.tag)
            {
                case "Object1":
                    model.connectedObject.GetComponent<Object1>().Connect(model.rb);
                    break;
                default:
                    Debug.Log(model.connectedObject.tag);
                    break;
            }
        }
    }
    private void DisConnectThread()
    {
        switch (model.connectedObject.tag)
        {
            case "Object1":
                model.connectedObject.GetComponent<Object1>().Disconnect();
                break;
            default:
                Debug.Log(model.connectedObject.tag);
                break;
        }
        model.connectedObject = null;
        model.connect = false;
    }
    private Vector2 GetDirection()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            return new Vector2(horizontal, vertical);
        }
        else
        {
            // 아무 키도 입력되지 않았을 때, 마지막 입력된 방향으로 발사
            // 여기서는 임의로 오른쪽 방향으로 설정함.
            return Vector2.right;
        }
    }
}
