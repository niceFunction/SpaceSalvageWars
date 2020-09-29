using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public int Maxhealth;
    public int currentHealth;

    public int ChangeHealth(int healthToChange)
    {
        currentHealth += healthToChange;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        return currentHealth;
    }

    public virtual void OnDestroy()
    {
        // Do stuff! Explosions
    }
}
