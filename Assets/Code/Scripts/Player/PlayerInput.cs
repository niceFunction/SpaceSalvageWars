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

        [Header("Movement"), Tooltip("Maximum speed that a Player can achieve"), Range(1f, 500f)]
        public float speed = 15f;
        public float rotationSpeed = 15f;
        public float maxVelocity = 15f;

        [Header("Grappling Hook")]
        public GrappleRope grappleRope;
        [Tooltip("Grapplehook prefarb that will be fired")]
        public GameObject grappleHookPrefab;
        public Transform grapplePointTransform;
        [Tooltip("How fast will the hook be fired?"), Range(1f, 50)]
        public float hookForce = 20f;

        private GameObject _hook;
        private Grapple _grapple;

        private Rigidbody2D _playerBody;
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
            //controls.Gameplay.FireHook.canceled += ctx => ReleaseHook();
        }

        private void OnEnable()
        {
            controls.Gameplay.Enable();
        }

        private void OnDisable()
        {
            controls.Gameplay.Disable();
        }

        private void OnGUI()
        {
            #if UNITY_EDITOR
            GUILayout.Label("Ship velocity: " + _playerBody.velocity);
            GUILayout.Label("Grapplehook: " + _hook);
            #endif
        }

        // Start is called before the first frame update
        void Start()
        {
            _playerBody = GetComponent<Rigidbody2D>();

        }

        private void Update()
        {
            if (_grapple != null)
            {
                if (_grapple.hookBody != null)
                {
                    // Attach a springjoint between hookBody & Player (or asteroid)
                    // Keep in mind that a spring joint may be needed 
                    // to be between asteroid & player instead of hook & asteroid
                }
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
                Debug.Log("Firing Hook");
                _hook = Instantiate(grappleHookPrefab,
                                                grapplePointTransform.position,
                                                grapplePointTransform.rotation);

                _grapple = _hook.GetComponent<Grapple>();
                
                Rigidbody2D hookBody = _hook.GetComponent<Rigidbody2D>();
                hookBody.AddForce(grapplePointTransform.right * hookForce, ForceMode2D.Impulse);
            }
            else if (_hook != null)
            {
                Debug.Log("Destroying Hook");
                Destroy(_hook);
            }
            //TODO Maybe changed Hold action (Input Action) when fireing grapple to Tap again
            //TODO and tap again to remove grapple hook
        }

        /*
        void ReleaseHook()
        {
            //Debug.Log("In Release Hook");
            if(_hook != null)
            {
                Debug.Log("Cancelled");
                Destroy(_hook);
                _hook = null;
            }

        }
        */
    }
}