using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRabbitSpawn : MonoBehaviour
{
    public GameObject rabbitPrefab;
    public GameObject deerPrefab;

    public int numToSpawn;
    public int timeTillNextSpawn = 90;
    

    public List<Transform> waypoints = new List<Transform>();

    public GameObject selectedPrefab;
    public Transform selectedWaypoint;

    void Awake()
    {
        
    }

    void Start()
    {
        Spawn();
        InvokeRepeating("Tick", timeTillNextSpawn, timeTillNextSpawn);
    }

    void Tick()
    {
        numToSpawn = 1;
        Spawn();
        TickContinue()
;    }

    void TickContinue()
    {
        InvokeRepeating("Tick", timeTillNextSpawn, timeTillNextSpawn);
    }

    private void Update()
    {
        
    }

    void Spawn()
    {
        float spawned = 0;
        
        while (spawned < numToSpawn) //runs for every animal told to spawn
        {
            if ((int)Random.Range(1, 5) != 4) //randomly selects rabbit or deer
            {
                selectedPrefab = rabbitPrefab;
            }
            else
            {
                selectedPrefab = deerPrefab;
            }

            //randomises spawn location
            selectedWaypoint = waypoints[(int)Random.Range(0, 9)];

            //spawns the animal
            Instantiate(selectedPrefab, selectedWaypoint.position, selectedWaypoint.rotation);
            spawned++;
        }
    }

}
