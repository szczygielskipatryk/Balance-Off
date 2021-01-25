using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerManager : MonoBehaviour
{
    public static bool left, right, center;
    private Vector3 accelerometer;

    void Update()
    {
        left=right=center = false;
        accelerometer = Input.acceleration;
        if (accelerometer.x < -0.30f)
        {
            left = true;
            StartCoroutine(Reset());
        }

        if (accelerometer.x <= 0.30f && accelerometer.x >= -0.30f)
        {
            center = true;
            StartCoroutine(Reset());
        }

        if (accelerometer.x > 0.30f)
        {
            right = true;
            StartCoroutine(Reset());
        }
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(1);

    }

}
