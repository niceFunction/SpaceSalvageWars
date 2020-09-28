using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RandomTorque : MonoBehaviour
{
    public Vector2 randomTorqueMinMax;

    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _body.AddTorque(Random.Range(randomTorqueMinMax.x, randomTorqueMinMax.y));
    }

}
