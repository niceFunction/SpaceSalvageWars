using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StandardBullet : MonoBehaviour
{
    public int playerId;
    public int currentPlayerId;

    public Transform normalRayCastOffset;

    public float bulletSpeed = 100f;
    public float bulletLifeTime = 1f;

    public GameObject hitSpawnObject;

    [Tooltip("Rotates hitSpawnObject in relation to angle of hit surface")]
    public bool isHitSpawnObjectRotateFromHitNormal;
    public bool isHitSpawnObjectRotateRandom;

    private Rigidbody2D _body;
    public Transform thisTransform;


    public virtual void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        thisTransform = transform;

        _body.AddForce(thisTransform.right * bulletSpeed);
        StartCoroutine("BulletLifeTimeCounter");
    }


    /* USE ON COLLISION INSTEAD OF TRIGGER
    public virtual void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<ActorPlayer>() != null)
        {
            var _actor = other.gameObject.GetComponent<ActorPlayer>();
            if (_actor.playerId == currentPlayerId) //Don't collide with this player
            {
                return;
            }
        }

        GameObject hitSpawnObjectInstance = Instantiate(hitSpawnObject, _transform.position, _transform.rotation);
        if (isHitSpawnObjectRotateFromHitNormal)
        {
            hitSpawnObjectInstance.transform.rotation = Quaternion.FromToRotation(Vector3.right, other.GetContact(0).normal);
        }
        else if (isHitSpawnObjectRotateRandom)
        {
            hitSpawnObjectInstance.transform.Rotate(new Vector3(0,0, Random.Range(0, 360)));
        }
        Destroy(gameObject);
    }
    */

    private IEnumerator BulletLifeTimeCounter()
    {
        float normalizedTime = 0;
        while (normalizedTime <= 1f) // In a while loop while counting down
        {
            normalizedTime += Time.deltaTime / bulletLifeTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}

