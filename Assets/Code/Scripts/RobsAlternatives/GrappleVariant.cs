using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrappleVariant : MonoBehaviour
{
    public LayerMask grabable;

    public Rigidbody2D playerBody;
    public Rigidbody2D hookBody;
    public ActorAsteroid actorAsteroid; 
    public GrappleHookShooter grappleHookShooter;

    private AudioSource _grappleSFX;
    public AudioClip grappleShootSFX;
    public AudioClip grappleHitSFX;

    private void Awake()
    {
        hookBody = GetComponent<Rigidbody2D>();
        _grappleSFX = GetComponent<AudioSource>();
    }


    private void Start()
    {
        _grappleSFX.PlayOneShot(grappleShootSFX);
    }


    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.GetComponent<ActorAsteroid>() != null)
        {
            var asteroid = collisionInfo.gameObject.GetComponent<ActorAsteroid>();

            var joint = grappleHookShooter.GetComponent<SpringJoint2D>();
            joint.connectedBody = asteroid.body;
            joint.enabled = true;

            grappleHookShooter.asteroidActor = asteroid;
            grappleHookShooter.hookConnected = true;
            asteroid.body.freezeRotation = true;
            var asteroidTransform = collisionInfo.transform;
            transform.SetParent(asteroidTransform, true);
            asteroid.SetAsteroidLayer("Players"); // TO DO Collectable set to collectableLayer...

            hookBody.simulated = false; // This puts hook at place and allows asteroid to continue

            _grappleSFX.PlayOneShot(grappleHitSFX);

        }
    }
}

