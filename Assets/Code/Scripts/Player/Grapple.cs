using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GT
{
    public class Grapple : MonoBehaviour
    {

        public LayerMask grabable;

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
            if (collisionInfo.gameObject.layer == grabable)
            {
                Debug.Log("Collided with asteroid");
                collisionInfo.gameObject.transform.parent = gra;
            }
        }
    }
}
