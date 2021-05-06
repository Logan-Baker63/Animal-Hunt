using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingControl : MonoBehaviour
{

    public GameObject Bullet;

    public bool canShoot = true;

    public Transform SpawnPoint;

    GameObject transportCart;

    public GameObject gun;

    // Start is called before the first frame update
    void Start()
    {
        transportCart = GameObject.FindGameObjectWithTag("Cart").gameObject;
        gun.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (transportCart.GetComponent<TransportCart>().isParented)
        {
            gun.SetActive(false);
        }
        else
        {
            gun.SetActive(true);
            
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
}
