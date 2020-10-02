using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorAsteroid : Actor
{
    public bool isDestructible = true;
    public bool isCollectable;

    public GameObject[] asteroidsToSpawnOnDeath;
    public Vector3[] asteroidsToSpawnOffsets; // Offset per asteroid set to same as above

    public GameObject deathSpawnFX;
    public GameObject collectibleObjectDrop;

    public Rigidbody2D body;
    private Transform _transform;

    public virtual void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        _transform = transform;
    }

    public override void OnDeath()
    {
        Instantiate(deathSpawnFX, _transform.position, _transform.rotation);

        if(asteroidsToSpawnOnDeath.Length == 0)
        {
            Destroy(gameObject);
            return;
        }


        for (int i = 0; i < asteroidsToSpawnOnDeath.Length; i++)
        {
            Instantiate(asteroidsToSpawnOnDeath[i], _transform.position + asteroidsToSpawnOffsets[i], _transform.rotation, _transform.parent);
        }

        if(collectibleObjectDrop != null)
        {
            Instantiate(collectibleObjectDrop, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }

    public void SetAsteroidLayer(string layerName)
    {
        gameObject.layer = LayerMask.NameToLayer(layerName);
    }

}
