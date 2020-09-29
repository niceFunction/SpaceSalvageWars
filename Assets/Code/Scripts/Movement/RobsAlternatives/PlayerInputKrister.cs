using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(MovementKrister)), RequireComponent(typeof(Weapon))]
public class PlayerInputKrister : MonoBehaviour
{
    private MovementKrister _shipMovement; // default value is null
    
    private Weapon _weapon;

    private Camera _camera;

    public PlayerControls _input;

    private Keyboard keyboard;

    public Vector2 moveInput;

    
    // value types
        // int, bool, struct
    // reference types - repoint that to different places in memory
        // class, string

    private void Awake()
    {
        

        _shipMovement = GetComponent<MovementKrister>();
        _weapon = GetComponent<Weapon>();
        //_camera = Camera.main;

        _input = new PlayerControls();

        _input.Gameplay.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        _input.Gameplay.Move.canceled += ctx => moveInput = Vector2.zero;
        
        //performed += ctx => MoveShip();
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
        Debug.Log(moveInput);
        // Only read input in Update
        //_carMovement.movementInput.Set(Input.GetAxis("Turn"), Input.GetAxis("Drive"));
        _shipMovement.movementInput.Set(moveInput.x, moveInput.y) ;
        //_weapon.aimAtPosition = _camera.ScreenToWorldPoint(Input.mousePosition);

        //if (keyboard.spaceKey.isPressed)
        //{
        //    _weapon.StartShooting();
        //}
        //else if (!keyboard.spaceKey.isPressed)
        //{
        //    _weapon.StopShooting();
        //}
    }

}
