using UnityEngine;
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
        _shipMovement = GetComponent<MovementKrister>();
        _weapon = GetComponent<Weapon>();
        _grappleHookShooter = GetComponent<GrappleHookShooter>();

        _input = new PlayerControls();

        _input.Gameplay.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        _input.Gameplay.Move.canceled += ctx => moveInput = Vector2.zero;

        _input.Gameplay.FireHook.performed += ctx => PlayerFireHook();

    }

    private void OnEnable()
    {
        _input.Gameplay.Enable();
    }

    private void OnDisable()
    {
        _input.Gameplay.Disable();
    }

    void FixedUpdate()
    {
        _shipMovement.movementInput.Set(moveInput.x, moveInput.y) ;
    }


    void PlayerFireHook()
    {
        _grappleHookShooter.GrappleShoot();
    }
}

