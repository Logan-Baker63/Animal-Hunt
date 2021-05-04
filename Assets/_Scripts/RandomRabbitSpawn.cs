using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRabbitSpawn : MonoBehaviour
{
    public GameObject rabbitPrefab;
    //public Transform deerPrefab;

    public int numToSpawn;
    

    public List<Transform> waypoints = new List<Transform>();

    public GameObject selectedPrefab;
    public Transform selectedWaypoint;

    void Awake()
    {
        
    }

    void Start()
    {
        Spawn();
    }

    private void Update()
    {
        
    }

    void Spawn()
    {
        float spawned = 0;
        
        while (spawned < numToSpawn)
        {
            if ((int)Random.Range(1, 5) != 4)
            {
                selectedPrefab = rabbitPrefab;
            }
            else
            {
                //selectedPrefab = deerPrefab;
                Debug.Log("Spawned Deer");
            }

            selectedWaypoint = waypoints[(int)Random.Range(0, 9)];

            Instantiate(selectedPrefab, selectedWaypoint.position, selectedWaypoint.rotation);
            spawned++;
        }
    }

}
