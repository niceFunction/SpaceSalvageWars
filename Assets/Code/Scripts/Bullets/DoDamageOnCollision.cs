using System;
using UnityEngine;

public class DoDamageOnCollision : MonoBehaviour
{

    public bool doPlayerDamage = true;
    public bool doAsteroidDamage = true;
    public int damageToDo;

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
        _actor.currentHealth = _actor.ChangeHealth(damageToDo);
    }

    private void DoDamageToAsteroid(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ActorAsteroid>() == null)
        {
            return;
        }

        var _actor = collision.gameObject.GetComponent<ActorAsteroid>();
        _actor.currentHealth = _actor.ChangeHealth(damageToDo);
    }


}
