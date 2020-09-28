﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


// GT = Group Two
namespace GT
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerInput : MonoBehaviour
    {

        PlayerControls controls;

        [Tooltip("Maximum speed that a Player can achieve"), Range(1f, 30f)]
        public float maxSpeed = 15f;
        public float rotationSpeed = 15f;

        private Rigidbody2D _playerBody;
        private Vector2 _move;
        private Vector3 _rotate;
        //private Vector2 _lookDirection;

        private void Awake()
        {
            controls = new PlayerControls();

            controls.Gameplay.Move.performed += ctx => _move = ctx.ReadValue<Vector2>();
            controls.Gameplay.Move.canceled += ctx => _move = Vector2.zero;

            controls.Gameplay.Rotate.performed += ctx => _rotate = ctx.ReadValue<Vector2>();
            controls.Gameplay.Rotate.canceled += ctx => _rotate = Vector2.zero;
        }

        private void OnEnable()
        {
            controls.Gameplay.Enable();
        }

        private void OnDisable()
        {
            controls.Gameplay.Disable();
        }

        // Start is called before the first frame update
        void Start()
        {
            _playerBody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            PlayerMove();
            PlayerRotate();
        }

        void PlayerMove()
        {

            Vector2 movePlayer = new Vector2(_move.x, _move.y) * Time.deltaTime;
            transform.Translate(movePlayer * maxSpeed, Space.World);

        }

        void PlayerRotate()
        {

            Vector3 rotatePlayer = new Vector3(0, 0, _rotate.z) * Time.deltaTime;
            transform.Rotate(rotatePlayer * rotationSpeed, Space.Self);
        }
    }

}