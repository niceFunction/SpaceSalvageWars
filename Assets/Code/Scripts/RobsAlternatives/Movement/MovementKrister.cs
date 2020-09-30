using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementKrister : MonoBehaviour // Carcontroller extends or inherits MonoBehaviour
{
    public float maxForwardSpeed = 8f;
    public float maxReverseSpeed = 4f;
    public float baseAcceleration = 20f;
    public float baseTurnAcceleration = 100f;
    public float speedToTurnTolerance = 0.1f; // at what speed are we allowed to turn
    public float maxTurnPower = 3f;

    [NonSerialized] public Vector2 movementInput; // x, y - Vector3 x, y, z
    
    [NonSerialized] public float forwardSpeed; // Current Speed
    [NonSerialized] public float desiredForwardSpeed; // Target Speed

    [NonSerialized] public float turnSpeed; // Current Speed
    [NonSerialized] public float desiredTurnSpeed; // Target Speed

    private Rigidbody2D _body;
    private Transform _transform;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();

       //using property
       // float speed = ForwardSpeed;
       // float value = Sum(10f, 15f);
    }

    private void Update() // Rule of Thumb use velocity speed related elements in FixedUpdate
    {
        MoveForward();
        Turn();
    }

    private void Turn()
    {
       // can only turn while driving
       //if (Mathf.Approximately(Mathf.Clamp(_body.velocity.sqrMagnitude - speedToTurnTolerance, 0f, 1f), 0f))
       // {
       //     return;
       // }

        // Calculate turn speed
        desiredTurnSpeed = movementInput.x * -maxTurnPower;

        // Turn Same for Reverse
        //Vector3 localVel = _transform.InverseTransformPoint(_body.velocity + (Vector2)transform.position);
        //desiredTurnSpeed *= (localVel.x > 0f ? 1f : -1f);
        //Remove This if you want original turn mechanics = Reverted Reverse Controls

        turnSpeed = Mathf.MoveTowards(turnSpeed, desiredTurnSpeed, baseTurnAcceleration * Time.fixedDeltaTime);
                                                                                                                // add calculated turn force = torque
        _body.AddTorque(turnSpeed);
    }

    private void MoveForward()
    {
        desiredForwardSpeed = movementInput.y * (movementInput.y > 0f ? maxForwardSpeed : maxReverseSpeed); // One line if statement ? istrue : else do this

        forwardSpeed = Mathf.MoveTowards(forwardSpeed, desiredForwardSpeed, baseAcceleration * Time.fixedDeltaTime);
        _body.AddForce(_transform.right * forwardSpeed, ForceMode2D.Force);
    }
}
