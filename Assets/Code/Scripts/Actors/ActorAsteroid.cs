using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorAsteroid : Actor
{
    public bool isDestructible = true;

    public GameObject[] asteroidsToSpawnOnDeath;
    public Vector3[] asteroidsToSpawnOffsets; // Offset per asteroid set to same as above

    public GameObject deathSpawnFX;
    public GameObject collectibleObjectDrop;

    private Transform _transform;
    private void Awake()
    {
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
            Instantiate(asteroidsToSpawnOnDeath[i], _transform.position + asteroidsToSpawnOffsets[i], _transform.rotation);
        }

        if(collectibleObjectDrop != null)
        {
            Instantiate(collectibleObjectDrop, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
