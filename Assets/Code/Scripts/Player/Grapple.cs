using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GT
{
    public class Grapple : MonoBehaviour
    {

        public LayerMask grabable;

        public Rigidbody2D hookBody;

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
            if (collisionInfo.gameObject.tag == "Asteroid")
            {
                Debug.Log("Collided with asteroid");
                var asteroidTransform = collisionInfo.transform;
                transform.SetParent(asteroidTransform, true);
                hookBody = GetComponent<Rigidbody2D>(); 
                hookBody.isKinematic = true; // Shouldnt access rigidbody like this, can be null
            }
        }
    }
}
