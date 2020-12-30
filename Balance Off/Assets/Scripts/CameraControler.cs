using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CameraControler : MonoBehaviour
{
    public Transform destination;
    private Vector3 distance;
    void Start()
    {
        distance = transform.position - destination.position;
    }

    
    void LateUpdate()
    {
        Vector3 newPosition =
            new Vector3(transform.position.x, transform.position.y, distance.z + destination.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, 120 * Time.deltaTime);
    }
}
