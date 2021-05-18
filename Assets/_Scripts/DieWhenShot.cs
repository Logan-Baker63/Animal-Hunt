using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieWhenShot : MonoBehaviour
{

    public GameObject bullet;
    public GameObject DeadRabbit;

    public RandomRabbitSpawn randomRabbitSpawn;

    Vector3 newPosition = new Vector3(0, 2f, 0);

    Animator anim;
    public bool isDead = false;

    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Bullet")
        {
            Destroy(other);
            isDead = true;
            anim.SetInteger("AnimIndex", 2);
            Instantiate(DeadRabbit, transform.position + newPosition, transform.rotation);
            Destroy(gameObject);

            randomRabbitSpawn.spawnedAnimals -= 1;


        }
    }

    private void Start()
    {
        randomRabbitSpawn = GameObject.Find("Rabbit Spawner").GetComponent<RandomRabbitSpawn>();
        bullet.SetActive(true);
        anim = GetComponent<Animator>();
    }

}
