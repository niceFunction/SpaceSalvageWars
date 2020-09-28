using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RandomAddForce : MonoBehaviour
{
    public Vector2 randomAddForceMinMaxX;
    public Vector2 randomAddForceMinMaxY;

    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _body.AddForce(new Vector2(Random.Range(randomAddForceMinMaxX.x, randomAddForceMinMaxX.y), Random.Range(randomAddForceMinMaxY.x, randomAddForceMinMaxY.y)));
    }

}
