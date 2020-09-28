using UnityEngine;

public class ScreenWrapAroundObject : MonoBehaviour
{
    public float screenWidthUnits = 9;
    public float screenHeightUnits = 6;

    void Update()
    {
        if (transform.position.x > screenWidthUnits)
        {

            transform.position = new Vector3(-screenWidthUnits, transform.position.y, 0);

        }
        if (transform.position.x < -screenWidthUnits)
        {
            transform.position = new Vector3(9, transform.position.y, 0);
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
