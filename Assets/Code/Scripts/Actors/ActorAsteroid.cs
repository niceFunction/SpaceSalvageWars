using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorAsteroid : Actor
{
    public bool isDestructible = true;

    public GameObject[] asteroidsToSpawnOnDeath;
    public Transform[] asteroidsToSpawnOffsets; // Offset per asteroid set to same as above

    public GameObject collectibleObjectDrop;

    public override void OnDeath()
    {
        for (int i = 0; i < asteroidsToSpawnOnDeath.Length; i++)
        {
            Instantiate(asteroidsToSpawnOnDeath[i], asteroidsToSpawnOffsets[i].position, asteroidsToSpawnOffsets[i].rotation);
        }

        if(collectibleObjectDrop != null)
        {
            Instantiate(collectibleObjectDrop, transform.position, transform.rotation);
        }
    }
}
