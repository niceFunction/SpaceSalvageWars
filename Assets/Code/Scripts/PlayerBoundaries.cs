using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundaries : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<GrappleVariant>() != null)
        {
            var _grapple = collision.gameObject.GetComponent<GrappleVariant>();
            _grapple.grappleHookShooter.DecoupleGrappleHook();
            Destroy(collision.gameObject); // Destroy Grapple if collided
        }
    }
}
