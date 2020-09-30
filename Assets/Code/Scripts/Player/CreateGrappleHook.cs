using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GT
{
    public class CreateGrappleHook : MonoBehaviour
    {
        [Tooltip("Reference the 'GrappleHook' prefab")]
        public GameObject grappleHook;
        //public GameObject grapplePoint;
        //public LineRenderer lineRenderer;

        private Vector2 _startRopePosition;
        private Vector2 _endRopePosition;
        // Start is called before the first frame update
        void Start()
        {
            //_startRopePosition = grapplePoint.transform.position;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void DrawRope()
        {

        }
    }
}