using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingControl : MonoBehaviour
{

    public GameObject Bullet;

    public bool canShoot = false;

    public Transform SpawnPoint;

    GameObject transportCart;

    public GameObject gun;

    public AudioSource gunshot;

    // Start is called before the first frame update
    void Start()
    {
        transportCart = GameObject.FindGameObjectWithTag("Cart").gameObject;
        gun.SetActive(true);
        canShoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (transportCart.GetComponent<TransportCart>().isParented)
        {
            gun.SetActive(false); //removes gun visibility
        }
        else
        {
            gun.SetActive(true); //adds gun visibility

            if (canShoot == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    gunshot.Play();
                    //Spawns bullets when clicking the shoot button
                    Instantiate(Bullet, SpawnPoint.position, SpawnPoint.rotation);
                }
            }
        }

    }
}
