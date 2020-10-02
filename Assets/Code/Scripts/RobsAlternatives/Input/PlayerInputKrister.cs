﻿using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(MovementKrister)), RequireComponent(typeof(Weapon))]
public class PlayerInputKrister : MonoBehaviour
{
    private ActorPlayer _actorPlayer;
        
    private MovementKrister _shipMovement;
    
    private Weapon _weapon;

    private GrappleHookShooter _grappleHookShooter;

    public PlayerControls _input;

    private Keyboard keyboard;

    public Vector2 moveInput;


    private void Awake()
    {
        _actorPlayer = GetComponent<ActorPlayer>();
        _shipMovement = GetComponent<MovementKrister>();
        _weapon = GetComponent<Weapon>();
        _grappleHookShooter = GetComponent<GrappleHookShooter>();

        SetPlayerControls();
    }


    public void SetPlayerControls()
    {
        switch (_actorPlayer.playerId)
        {
            case 1:
                _input = new PlayerControls();
                _input.Player1.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
                _input.Player1.Move.canceled += ctx => moveInput = Vector2.zero;
                _input.Player1.FireHook.performed += ctx => PlayerFireHook();
                break;
            case 2:
                _input = new PlayerControls();
                _input.Player2.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
                _input.Player2.Move.canceled += ctx => moveInput = Vector2.zero;
                _input.Player2.FireHook.performed += ctx => PlayerFireHook();
                break;
            case 3:
                _input = new PlayerControls();
                _input.Player3.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
                _input.Player3.Move.canceled += ctx => moveInput = Vector2.zero;
                _input.Player3.FireHook.performed += ctx => PlayerFireHook();
                break;
            case 4:
                _input = new PlayerControls();
                _input.Player4.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
                _input.Player4.Move.canceled += ctx => moveInput = Vector2.zero;
                _input.Player4.FireHook.performed += ctx => PlayerFireHook();
                break;
        }
    }


    private void OnEnable()
    {
        switch (_actorPlayer.playerId)
        {
            case 1:
                _input.Player1.Enable();
                break;
            case 2:
                _input.Player2.Enable();
                break;
            case 3:
                _input.Player3.Enable();
                break;
            case 4:
                _input.Player4.Enable();
                break;
        }
    }

    private void OnDisable()
    {
        switch (_actorPlayer.playerId)
        {
            case 1:
                _input.Player1.Disable();
                break;
            case 2:
                _input.Player2.Disable();
                break;
            case 3:
                _input.Player3.Disable();
                break;
            case 4:
                _input.Player4.Disable();
                break;
        }
    }

    void FixedUpdate()
    {
        _shipMovement.movementInput.Set(moveInput.x, moveInput.y) ;
    }


    // TO DO ADD ROTATION INPUT FOR ASTEROID MOVEMENT

    void PlayerFireHook()
    {
        _grappleHookShooter.GrappleShoot(); // HOOKSHOOTER CONTROLS ASTEROID MOVEMENT
    }
}

