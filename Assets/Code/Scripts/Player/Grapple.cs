using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GT
{
    public class Grapple : MonoBehaviour
    {

        public LayerMask grabable;

        public Rigidbody2D playerBody;
        public Rigidbody2D hookBody;
        public ActorAsteroid actorAsteroid; // Added recently
        public PlayerInput playerInput; // Added recently

        //[Tooltip("Get the grapplehook point position")]
        //public GameObject grappleHookPoint;
        //public TrailRenderer grappleRopeTrail;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter2D(Collision2D collisionInfo)
        {

            //if ((collisionInfo.gameObject.layer & grabable) == grabable)
            //if (collisionInfo.gameObject.tag == "Asteroid")
            if(collisionInfo.gameObject.GetComponent<ActorAsteroid>() != null)
            {

                //Start: This makes the grapple attach itself (as a child) to asteroid
                //TODO reminder: Decrease Asteroid mass when hook is attached?
                var asteroid = collisionInfo.gameObject.GetComponent<ActorAsteroid>();

                var joint = playerInput.GetComponent<SpringJoint2D>();
                joint.connectedBody = asteroid.body;
                joint.enabled = true;

                playerInput.asteroidActor = asteroid;
                asteroid.body.freezeRotation = true;
                //End

                Debug.Log("Collided with asteroid");
                var asteroidTransform = collisionInfo.transform;
                transform.SetParent(asteroidTransform, true);
                hookBody = GetComponent<Rigidbody2D>(); 
                hookBody.isKinematic = true; // Shouldnt access rigidbody like this, can be null
            }
        }
    }
}
