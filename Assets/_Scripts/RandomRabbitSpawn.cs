using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRabbitSpawn : MonoBehaviour
{
    public GameObject rabbitPrefab;
    public GameObject deerPrefab;
    public GameObject foxPrefab;
    public int maxAnimals;
    public int spawnedAnimals = 0;

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
        
        if (spawnedAnimals >= maxAnimals)
        {

        }
        else
        {
            while (spawned < numToSpawn) //runs for every animal told to spawn
            {
                if ((int)Random.Range(1, 10) >= 5) //randomly selects a rabbit, deer, or fox
                {
                    selectedPrefab = rabbitPrefab;
                }
                else if ((int)Random.Range(1, 10) == 9)
                {
                    selectedPrefab = foxPrefab;
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
                spawnedAnimals++;
            }
        }

        
    }

}
