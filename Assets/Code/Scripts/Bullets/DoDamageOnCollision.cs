using System;
using UnityEngine;

public class DoDamageOnCollision : MonoBehaviour
{

    public bool doPlayerDamage = true;
    public bool doAsteroidDamage = true;
    public int damageToDo;

    public GameObject collisionFXSpawn;

    public bool isCollisionFXSpawnRotateFromHitNormal;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (doPlayerDamage)
        {
            DoDamageToPlayer(collision);
        }
        if (doAsteroidDamage)
        {
            DoDamageToAsteroid(collision);
        }
    }

    private void DoDamageToPlayer(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ActorPlayer>() == null)
        {
            return;
        }

        var _actor = collision.gameObject.GetComponent<ActorPlayer>();
        _actor.currentHealth = _actor.ChangeHealth(-damageToDo);

        if(collisionFXSpawn != null)
        {
            GameObject hitSpawnObjectInstance = Instantiate(collisionFXSpawn, collision.GetContact(0).point, transform.rotation);
            if (isCollisionFXSpawnRotateFromHitNormal)
            {
                hitSpawnObjectInstance.transform.rotation = Quaternion.FromToRotation(Vector3.right, collision.GetContact(0).normal);
            }
        }

    }

    private void DoDamageToAsteroid(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ActorAsteroid>() == null)
        {
            return;
        }

        var _actor = collision.gameObject.GetComponent<ActorAsteroid>();
        _actor.currentHealth = _actor.ChangeHealth(-damageToDo);
    }


}
