using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrappleHookShooter : MonoBehaviour
{
    [Header("Grappling Hook"), Tooltip("Grapplehook prefarb that will be fired")]
    public GameObject grappleHookPrefab;
    public Transform grapplePointTransform;
    [Tooltip("How fast will the hook be fired?"), Range(1f, 50)]
    public float hookForce = 20f;
    public SpringJoint2D hookSpring;
    public ActorAsteroid asteroidActor;

    private GameObject _hook;
    private GrappleVariant _grapple;

    private ActorPlayer _playerBody;

    // RENDER LINE BETWEEN PLAYER AND HOOK
    public bool hookReleased;
    public bool hookConnected;
    public Vector2 lineAndPlayer;
    public LineRenderer lineRenderer;

    public void Start()
    {
        _playerBody = GetComponent<ActorPlayer>();
        lineRenderer = GetComponent<LineRenderer>();

        hookSpring.enabled = false;
    }

    private void Update()
    {
        if (hookReleased)
        {
            lineRenderer.SetPosition(0, _playerBody.body.position);
            if (hookConnected)
            {
                lineRenderer.SetPosition(1, asteroidActor.body.position);
                return;
            }
            lineRenderer.SetPosition(1, _grapple.hookBody.position);
        }
    }


    public void GrappleShoot()
    {
        if (_hook == null)
        {
            hookReleased = true;
            lineRenderer.enabled = true;
            Debug.Log("Firing Hook");
            _hook = Instantiate(grappleHookPrefab,
                                grapplePointTransform.position,
                                grapplePointTransform.rotation);

            _grapple = _hook.GetComponent<GrappleVariant>();
            _grapple.grappleHookShooter = this;
            _grapple.playerBody = _playerBody.body;

            Rigidbody2D hookBody = _hook.GetComponent<Rigidbody2D>();
            hookBody.AddForce(grapplePointTransform.right * hookForce, ForceMode2D.Impulse);
        }
        else if (_hook != null)
        {
            DecoupleGrappleHook();
        }
    }

    public void DecoupleGrappleHook()
    {
        hookConnected = false;
        hookReleased = false;
        lineRenderer.enabled = false;
        if (asteroidActor != null)
        {
            asteroidActor.SetAsteroidLayer("Asteroids");
            asteroidActor = null;
        }
        hookSpring.enabled = false;
        Debug.Log("Destroying Hook");
        if(_hook != null)
        {
            Destroy(_hook);
        }
    }
}
