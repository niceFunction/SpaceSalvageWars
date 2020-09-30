using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorPlayer : Actor
{
    public int playerId;

    public Transform playerBase;
    public GameObject respawnFX;
    public GameObject deathExplosion;

    //C# Delegate/Events
    public delegate Event OnChangePlayerHealth();
    public event OnChangePlayerHealth OnChangeHealthHandler;

    public Rigidbody2D body;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        body = GetComponent<Rigidbody2D>();
    }

    public override int ChangeHealth(int healthToChange)
    {
        currentHealth += healthToChange;

        OnChangeHealthHandler?.Invoke(); // Subscribe UI to this event

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            OnDeath();
        }
        return currentHealth;
    }

    public override void OnDeath()
    {
        //Instantiate(deathExplosion, _transform.position, _transform.rotation); // TO DO DEATH EXPLOSION FX
        RespawnAtBase();
    }

    private void RespawnAtBase()
    {
        // Instantiate(respawnFX, playerBase.position, playerBase.rotation); // TO DO RESPAWN FX
        body.velocity = new Vector2(); // Reset Motion
        _transform.position = playerBase.position;
    }
}
