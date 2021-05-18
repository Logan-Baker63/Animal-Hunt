using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnterShop : MonoBehaviour
{

    public GameObject Scope;
    public GameObject MoneyDisplay;
    public GameObject ShopMenu;
    public RandomRabbitSpawn RandomRabbitSpawn;
    public SimpleMovement SimpleMovement;
    public ShootingControl ShootingControl;
    public GameManager GameManager;

    public AudioSource cashRegister;
    public AudioSource doorbell;

    private void Start()
    {
        ShopMenu.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            EnterTheShop();
        }
    }

    void EnterTheShop()
    {
        doorbell.Play();

        ShootingControl.canShoot = false;
        SimpleMovement.canMove = false;

        //resets UI accordingly
        Scope.SetActive(false);
        ShopMenu.SetActive(true);
        MoneyDisplay.SetActive(true);

        //unlocks the cursor
        Cursor.lockState = CursorLockMode.None;

    }

    public void IncreaseMovementSpeed()
    {

        if (GameManager.GetComponent<GameManager>().playerMoney >= 100f)
        {
            cashRegister.Play();
            SimpleMovement.originalPlayerSpeed += 0.5f;
            GameManager.GetComponent<GameManager>().playerMoney -= 100f;
        }
        
        
    }

    public void IncreaseSpawnRate()
    {
        if (GameManager.GetComponent<GameManager>().playerMoney >= 1000f)
        {
            
            if (RandomRabbitSpawn.timeTillNextSpawn <= 2)
            {
                RandomRabbitSpawn.timeTillNextSpawn = 2;
                Debug.Log("Limit reached");
            }
            else
            {
                cashRegister.Play();
                RandomRabbitSpawn.timeTillNextSpawn -= 2;
                GameManager.GetComponent<GameManager>().playerMoney -= 1000f;
            }

            
            
        }
    }

    public void ExitTheShop()
    {
        SimpleMovement.canMove = true;
        ShootingControl.canShoot = true;

        doorbell.Play();
        ShopMenu.SetActive(false);

        //locks the cursor
        Cursor.lockState = CursorLockMode.Locked;


    }

}
