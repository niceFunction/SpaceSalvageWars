using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StandardBullet : MonoBehaviour
{
    public int playerId;

    public float bulletSpeed = 100f;
    public float bulletLifeTime = 1f;

    public GameObject hitSpawnObject;

    [Tooltip("Rotates hitSpawnObject in relation to angle of hit surface")]
    public bool isHitSpawnObjectRotateFromHitNormal;
    public bool isHitSpawnObjectRotateRandom;

    private Rigidbody2D _body;
    private Transform _transform;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _transform = transform;

        _body.AddForce(_transform.right * bulletSpeed);
        StartCoroutine("BulletLifeTimeCounter");
    }

    public virtual void OnCollisionEnter2D(Collision2D other)
    {
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

