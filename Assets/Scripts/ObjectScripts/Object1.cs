using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object1 : MonoBehaviour 
{
    private DistanceJoint2D distanceJoint2D;

    private void Start()
    {
        distanceJoint2D = GetComponent<DistanceJoint2D>();
    }

    public void Connect(Rigidbody2D player)
    {
        distanceJoint2D.enabled = true;
        distanceJoint2D.connectedBody = player;
    }

    public void Disconnect()
    {
        distanceJoint2D.enabled = false;
        distanceJoint2D.connectedBody = null;
    }
}
