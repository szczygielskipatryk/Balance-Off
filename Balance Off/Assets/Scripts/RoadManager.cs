using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject[] roadObjects;

    private float _zPosition = 0;
    private readonly float _roadLenght = 30;
    private int activeRoads = 10;
    public Transform PlayerTransform;
    private List<GameObject>activeRoad= new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < activeRoads; i++)
        {
            if (i == 0)
            {
                SpawnRoad(0);

            }
            else
            {
                SpawnRoad(Random.Range(0, roadObjects.Length));
            }
        }

    }

    void Update()
    {
        if (PlayerTransform.position.z -35 > _zPosition - (activeRoads * _roadLenght))
        {
            SpawnRoad(Random.Range(0, roadObjects.Length));
            DeleteRoad();
        }
    }

    public void SpawnRoad(int index)
    {   
        GameObject temp = Instantiate(roadObjects[index], transform.forward * _zPosition, transform.rotation);
        activeRoad.Add(temp);
        _zPosition += _roadLenght;
    }

    private void DeleteRoad()
    {
        Destroy(activeRoad[0]);
        activeRoad.RemoveAt(0);
    }
}
