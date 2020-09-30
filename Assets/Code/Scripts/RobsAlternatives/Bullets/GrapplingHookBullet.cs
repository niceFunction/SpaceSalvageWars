using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHookBullet : StandardBullet
{
    public ActorPlayer actorPlayer; // THE WEAPON WHEN FIRED SETS THE VARIABLE HERE


    public override void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        thisTransform = transform;

        body.AddForce(thisTransform.right * bulletSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<CollectableObject>() != null)
        {
            ConnectToCollectableObject(collision);
        }
        if(collision.gameObject.GetComponent<ActorAsteroid>() != null)
        {
            ConnectToAsteroid(collision);
        }
    }

    public void ConnectToCollectableObject(Collision2D collision)
    {
        CollectableObject _collectableObject = collision.gameObject.GetComponent<CollectableObject>();
        _collectableObject.ConnectThisBody(true, actorPlayer.body);
        transform.SetParent(_collectableObject.transform);
    }

    public void ConnectToAsteroid(Collision2D collision)
    {
        ActorAsteroid _asteroid = collision.gameObject.GetComponent<ActorAsteroid>();
        _asteroid.ConnectThisBody(true, actorPlayer.body);
        transform.SetParent(_asteroid.transform);
    }
}
