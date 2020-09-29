using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ScreenWrapAroundObject : MonoBehaviour
{
    public float screenWidthUnits = 9;
    public float screenHeightUnits = 6;

    private Collider2D _collider;
    private Vector3 _colliderExtents;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _colliderExtents = _collider.bounds.extents;

        screenHeightUnits += _colliderExtents.y;
        screenWidthUnits += _colliderExtents.x;
    }

    void Update()
    {


        if (transform.position.x > screenWidthUnits)
        {

            transform.position = new Vector3(-screenWidthUnits, transform.position.y, 0);

        }
        if (transform.position.x < -screenWidthUnits)
        {
            transform.position = new Vector3(screenWidthUnits, transform.position.y, 0);
        }

        if (transform.position.y > screenHeightUnits)
        {
            transform.position = new Vector3(transform.position.x, -screenHeightUnits, 0);
        }

        if (transform.position.y < -screenHeightUnits)
        {
            transform.position = new Vector3(transform.position.x, screenHeightUnits, 0);
        }
    }
}
