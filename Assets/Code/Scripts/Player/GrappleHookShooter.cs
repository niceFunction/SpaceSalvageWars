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


    public void Start()
    {
        _playerBody = GetComponent<ActorPlayer>();

        hookSpring.enabled = false;
    }


    public void GrappleShoot()
    {
        if (_hook == null)
        {
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
            hookSpring.enabled = false;
            Debug.Log("Destroying Hook");
            Destroy(_hook);
        }
    }
}
