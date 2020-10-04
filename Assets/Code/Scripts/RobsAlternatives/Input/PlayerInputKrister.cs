using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.PlayerLoop;

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
    public Vector2 rotationInput;


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

                _input.Player1.Rotate.performed += ctx => rotationInput = ctx.ReadValue<Vector2>();
                _input.Player1.Rotate.canceled += ctx => rotationInput = Vector2.zero;

                _input.Player1.FireHook.performed += ctx => PlayerFireHook();
                _input.Player1.FireShoot.performed += ctx => PlayerFireShoot(true);
                _input.Player1.FireShoot.canceled += ctx => PlayerFireShoot(false);

                break;
            case 2:
                _input = new PlayerControls();
                _input.Player2.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
                _input.Player2.Move.canceled += ctx => moveInput = Vector2.zero;

                _input.Player2.Rotate.performed += ctx => rotationInput = ctx.ReadValue<Vector2>();
                _input.Player2.Rotate.canceled += ctx => rotationInput = Vector2.zero;

                _input.Player2.FireHook.performed += ctx => PlayerFireHook();
                _input.Player2.FireShoot.performed += ctx => PlayerFireShoot(true);
                _input.Player2.FireShoot.canceled += ctx => PlayerFireShoot(false);

                break;
            case 3:
                _input = new PlayerControls();
                _input.Player3.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
                _input.Player3.Move.canceled += ctx => moveInput = Vector2.zero;

                _input.Player3.Rotate.performed += ctx => rotationInput = ctx.ReadValue<Vector2>();
                _input.Player3.Rotate.canceled += ctx => rotationInput = Vector2.zero;

                _input.Player3.FireHook.performed += ctx => PlayerFireHook();
                _input.Player3.FireShoot.performed += ctx => PlayerFireShoot(true);
                _input.Player3.FireShoot.canceled += ctx => PlayerFireShoot(false);

                break;
            case 4:
                _input = new PlayerControls();
                _input.Player4.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
                _input.Player4.Move.canceled += ctx => moveInput = Vector2.zero;

                _input.Player4.Rotate.performed += ctx => rotationInput = ctx.ReadValue<Vector2>();
                _input.Player4.Rotate.canceled += ctx => rotationInput = Vector2.zero;

                _input.Player4.FireHook.performed += ctx => PlayerFireHook();
                _input.Player4.FireShoot.performed += ctx => PlayerFireShoot(true);
                _input.Player4.FireShoot.canceled += ctx => PlayerFireShoot(false);

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
        _shipMovement.movementInput.Set(moveInput.x, moveInput.y);
        rotationInput.Set(rotationInput.x,rotationInput.y);
    }


    // TO DO ADD ROTATION INPUT FOR ASTEROID MOVEMENT

    void PlayerFireHook()
    {
        _grappleHookShooter.GrappleShoot(); // HOOKSHOOTER CONTROLS ASTEROID MOVEMENT
    }

    void PlayerFireShoot(bool start)
    {
        if (start)
        {
            _weapon.StartShooting();
        }
        else
        {
            _weapon.StopShooting();
        }
    }
}

