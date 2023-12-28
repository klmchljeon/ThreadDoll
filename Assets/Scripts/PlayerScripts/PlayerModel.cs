using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public float moveSpeed { get; set; } = 5f;
    public float jumpForce { get; set; } = 9.3f;
    public bool connect { get; set; } = false;
    public Transform connectedObject { get; set; } = null;

    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float horizontal)
    {
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
    }
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
 