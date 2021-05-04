using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingControl : MonoBehaviour
{

    public GameObject Bullet;

    public bool canShoot = true;

    public Transform SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Spawns bullets when clicking the shoot button
                Instantiate(Bullet, SpawnPoint.position, SpawnPoint.rotation);
            }
        }
        
        
    }
}
