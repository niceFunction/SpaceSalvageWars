using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public virtual int ChangeHealth(int healthToChange)
    {
        currentHealth += healthToChange;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if(currentHealth <= 0)
        {
            OnDeath();
        }
        return currentHealth;
    }

    public virtual void OnDeath()
    {
        // Do stuff! Explosions
    }
}
