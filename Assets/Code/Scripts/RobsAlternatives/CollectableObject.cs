using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    public int scorePoints = 1; // or just nuggets collected?

    public SpringJoint2D joint;

    public float maxDistanceOfObjectJoint = 2f;
    private void Awake()
    {
        joint = GetComponent<SpringJoint2D>();
        joint.enabled = false;
    }

    public void ConnectThisBody(bool isConnected, Rigidbody2D body)
    {
        if (isConnected)
        {
            joint.enabled = true;
            joint.connectedBody = body;
            joint.distance = maxDistanceOfObjectJoint;
        }
        else
        {
            joint.enabled = false;
            joint.connectedBody = null;
        }
        
    }

}
