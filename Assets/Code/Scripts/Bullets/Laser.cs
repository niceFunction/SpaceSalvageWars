using UnityEngine;
public class Laser : StandardBullet
{

    public override void Awake()
    {
        base.Awake();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ActorPlayer>() != null)
        {
            var _actor = collision.gameObject.GetComponent<ActorPlayer>();
            if (_actor.playerId == currentPlayerId) //Don't collide with this player
            {
                return;
            }
        }

        GameObject hitSpawnObjectInstance = Instantiate(hitSpawnObject, thisTransform.position, thisTransform.rotation);
        if (isHitSpawnObjectRotateFromHitNormal) // This doesn't completely work... OnCollisionWorks however
        {
            RaycastHit hit;
            Debug.DrawRay(normalRayCastOffset.position, thisTransform.right * 2);
            if (Physics.Raycast(normalRayCastOffset.position, thisTransform.right * 2, out hit))
            {
                hitSpawnObjectInstance.transform.rotation = Quaternion.FromToRotation(Vector3.right, hit.normal);
                Debug.Log(hit.normal);
            }
        }
        else if (isHitSpawnObjectRotateRandom)
        {
            hitSpawnObjectInstance.transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
        }
        Destroy(gameObject);
    }
}
