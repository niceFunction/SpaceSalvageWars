using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GT
{
    public class GrappleRope : MonoBehaviour
    {
        //public PlayerInput playerInput;

        //[Tooltip("Reference the 'GrappleHook' prefab")]
        //public GameObject grappleHook;
        [Tooltip("Can be the first point")]
        public PlayerInput playerInput;

        [Tooltip("The gameobject where the grapplehook spawns from")]
        public GameObject grappleSpawnPoint;

        [Tooltip("Second point point")]
        public Grapple grappleHookPoint;
        //public GameObject grapplePoint;
        public LineRenderer lineRenderer;

        [SerializeField]
        private int _linePointAmount = 40;

        private void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            DrawRope();
        }

        void DrawRope()
        {
            
        }
    }
}