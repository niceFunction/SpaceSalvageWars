using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;


// GT = Group Two
namespace GT
{

    //Nice grappling hook with code & tutorial how to use it: https://www.youtube.com/watch?v=dnNCVcVS6uw
    // How grappling is done in Spider man 2: https://gamedevelopment.tutsplus.com/tutorials/swinging-physics-for-player-movement-as-seen-in-spider-man-2-and-energy-hook--gamedev-8782
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerInput : MonoBehaviour
    {

        PlayerControls controls;

        [Header("Movement"), Tooltip("'Speed' that a Player can achieve"), Range(1f, 500f)]
        public float speed = 15f;
        [Tooltip("Players rotation speed")]
        public float rotationSpeed = 15f;
        [Tooltip("How much velocity can a Player achieve before it's stopped?")]
        public float maxVelocity = 15f;

        [Header("Grappling Hook"), Tooltip("Grapplehook prefarb that will be fired")]
        public GameObject grappleHookPrefab;
        public Transform grapplePointTransform;
        [Tooltip("How fast will the hook be fired?"), Range(1f, 50)]
        public float hookForce = 20f;
        public SpringJoint2D hookSpring;
        public ActorAsteroid asteroidActor;


        [Header("Rope"), Tooltip("Line renderer")]
        public LineRenderer ropeRenderer;
        [SerializeField]
        private int _percision = 40;
        [HideInInspector]
        public bool isGrappling = true;

        private GameObject _hook;
        private Grapple _grapple;
        [Space(15f)]
        public Rigidbody2D _playerBody;
        private Vector2 _move;
        private Vector3 _rotate;

        private void Awake()
        {
            controls = new PlayerControls();

            controls.Gameplay.Move.performed += ctx => _move = ctx.ReadValue<Vector2>();
            controls.Gameplay.Move.canceled += ctx => _move = Vector2.zero;

            controls.Gameplay.Rotate.performed += ctx => _rotate = ctx.ReadValue<Vector2>();
            controls.Gameplay.Rotate.canceled += ctx => _rotate = Vector2.zero;

            controls.Gameplay.FireHook.performed += ctx => PlayerFireHook();
        }

        private void OnEnable()
        {
            controls.Gameplay.Enable();
            hookSpring.enabled = true;

            ropeRenderer.positionCount = _percision;

            ropeRenderer.enabled = true;
        }

        private void OnDisable()
        {
            controls.Gameplay.Disable();
            hookSpring.enabled = false;

            ropeRenderer.enabled = false;
            //isGrappling = false;
        }

        private void OnGUI()
        {
            #if UNITY_EDITOR
            GUILayout.Label("Ship velocity: " + _playerBody.velocity);
            GUILayout.Label("Grapplehook: " + _hook);
            //GUILayout.Label("GrappleHook position: " + _grapple.hookBody.position);
            //GUILayout.Label("Player position: " + _playerBody.position);
            #endif
        }

        // Start is called before the first frame update
        void Start()
        {
            hookSpring.enabled = false;
            _playerBody = GetComponent<Rigidbody2D>();
            ropeRenderer.enabled = false;
        }

        private void Update()
        {
            if (_hook != null)
            {

                ropeRenderer.SetPosition(1, _playerBody.position);
                ropeRenderer.SetPosition(0, _grapple.hookBody.position);
            }
            //DrawRope();
            if (_grapple != null)
            {
                if (_grapple.hookBody != null)
                {

                    //Debug.Log("Something happend");
                    //hookSpring.enabled = true;
                    
                    //hookSpring.connectedBody = asteroidActor.body;
                    //hookSpring.connectedBody = ;
                    //TODO Attach springjoint to Player, find how to attach "Connected" RB to Hook or Asteroid
                    // Attach a springjoint between hookBody & Player (or asteroid)
                    // Keep in mind that a spring joint may be needed 
                    // to be between asteroid & player instead of hook & asteroid
                }
            }
            if (asteroidActor != null)
            {
                //asteroidActor.body.
            }
        }

        private void FixedUpdate()
        {
            PlayerMove();
            PlayerRotate();
        }

        void PlayerMove()
        {
            Vector2 movePlayer = new Vector2(_move.x, _move.y) * Time.deltaTime;

            _playerBody.AddForce(movePlayer * (speed * 2));
            _playerBody.velocity = Vector2.ClampMagnitude(_playerBody.velocity, maxVelocity);
        }

        void PlayerRotate()
        {
            Vector3 rotatePlayer = new Vector3(0, 0, -_rotate.x) * Time.deltaTime;
            _playerBody.AddTorque(_rotate.x * rotationSpeed);
        }

        void PlayerFireHook()
        {
            if(_hook == null)
            {
                //hookSpring.enabled = true;
                Debug.Log("Firing Hook");
                _hook = Instantiate(grappleHookPrefab,
                                    grapplePointTransform.position,
                                    grapplePointTransform.rotation);

                _grapple = _hook.GetComponent<Grapple>();
                
                _grapple.playerBody = _playerBody;
                _grapple.playerInput = this;

                Rigidbody2D hookBody = _hook.GetComponent<Rigidbody2D>();
                hookBody.AddForce(grapplePointTransform.right * hookForce, ForceMode2D.Impulse);
                

                ropeRenderer.enabled = true;

            }
            else if (_hook != null)
            {

                ropeRenderer.enabled = false;
                hookSpring.enabled = false;
                Debug.Log("Destroying Hook");
                Destroy(_hook);
            }
        }

        void DrawRope()
        {
            /*
            ropeRenderer = GetComponent<LineRenderer>();
            for (int i = 0; i < 40; i++)
            {
                ropeRenderer.SetPosition(i , _grapple.transform.position);
            }
            */
        }
    }
}