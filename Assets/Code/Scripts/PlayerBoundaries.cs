using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundaries : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<GrappleVariant>() != null)
        {
            Destroy(collision.gameObject); // Destroy Grapple if collided
        }
    }
}
