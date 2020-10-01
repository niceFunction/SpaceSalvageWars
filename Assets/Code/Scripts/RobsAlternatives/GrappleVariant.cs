using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrappleVariant : MonoBehaviour
{
    public LayerMask grabable;

    public Rigidbody2D playerBody;
    public Rigidbody2D hookBody;
    public ActorAsteroid actorAsteroid; 
    public GrappleHookShooter grappleHookShooter; 

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.GetComponent<ActorAsteroid>() != null)
        {
            var asteroid = collisionInfo.gameObject.GetComponent<ActorAsteroid>();

            var joint = grappleHookShooter.GetComponent<SpringJoint2D>();
            joint.connectedBody = asteroid.body;
            joint.enabled = true;

            grappleHookShooter.asteroidActor = asteroid;
            asteroid.body.freezeRotation = true;

            Debug.Log("Collided with asteroid");
            var asteroidTransform = collisionInfo.transform;
            transform.SetParent(asteroidTransform, true);
            //if (hookBody.GetComponent<Rigidbody2D>() != null)
            //{
            //    hookBody = GetComponent<Rigidbody2D>();
            //    hookBody.isKinematic = true;
            //}
        }
    }
}

