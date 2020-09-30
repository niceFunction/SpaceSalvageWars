using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ScreenWrapAroundObject : MonoBehaviour
{
    public float screenWidthUnits = 9;
    public float screenHeightUnits = 6;

    public float maxScreenWidthUnits = 12;
    public float maxScreenHeightUnits = 10;

    private Collider2D _collider;
    private Vector3 _colliderExtents;

    private Transform _transform;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _colliderExtents = _collider.bounds.extents;

        screenHeightUnits += _colliderExtents.y;
        screenWidthUnits += _colliderExtents.x;

        maxScreenHeightUnits += _colliderExtents.y;
        maxScreenWidthUnits += _colliderExtents.x;

        _transform = transform;
    }

    void Update()
    {


        if (_transform.position.x > screenWidthUnits)
        {

            _transform.position = new Vector3(-screenWidthUnits, _transform.position.y, 0);

        }
        if (_transform.position.x < -screenWidthUnits)
        {
            _transform.position = new Vector3(screenWidthUnits, _transform.position.y, 0);
        }

        if (_transform.position.y > screenHeightUnits)
        {
            _transform.position = new Vector3(_transform.position.x, -screenHeightUnits, 0);
        }

        if (_transform.position.y < -screenHeightUnits)
        {
            _transform.position = new Vector3(_transform.position.x, screenHeightUnits, 0);
        }

        // DESTROY GAME OBJECT IF TOO FAR AWAY

        if (_transform.position.x > maxScreenWidthUnits)
        {

            Destroy(gameObject);

        }
        if (_transform.position.x < -maxScreenWidthUnits)
        {
            Destroy(gameObject);
        }

        if (_transform.position.y > maxScreenHeightUnits)
        {
            Destroy(gameObject);
        }

        if (_transform.position.y < -maxScreenHeightUnits)
        {
            Destroy(gameObject);
        }

    }
}
