using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObjAfterSeconds : MonoBehaviour
{
    public float secondsToDestroy = 5f;
    void Start()
    {
        StartCoroutine("CountDownTimer");
    }


    private IEnumerator CountDownTimer()
    {
        float normalizedTime = 0;
        while (normalizedTime <= 1f) // In a while loop while counting down
        {
            normalizedTime += Time.deltaTime / secondsToDestroy;
            yield return null;
        }
        Destroy(gameObject);
    }

}
