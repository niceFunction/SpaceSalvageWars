using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamageOnTrigger : MonoBehaviour
{
    public bool doPlayerDamage = true;
    public bool doAsteroidDamage = true;
    public int damageToDo;

    public int playerId;

    public void OnTriggerEnter2D(Collider2D collision)
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

    private void DoDamageToPlayer(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ActorPlayer>() == null)
        {
            return;
        }
        var _actor = collision.gameObject.GetComponent<ActorPlayer>();
        if(_actor.playerId != playerId)
        {
            _actor.currentHealth = _actor.ChangeHealth(-damageToDo);
        }
    }

    private void DoDamageToAsteroid(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ActorAsteroid>() == null)
        {
            return;
        }

        var _actor = collision.gameObject.GetComponent<ActorAsteroid>();
        _actor.currentHealth = _actor.ChangeHealth(-damageToDo);
    }
}
