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
    public GameManager GameManager;

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
                RandomRabbitSpawn.timeTillNextSpawn -= 2;
                GameManager.GetComponent<GameManager>().playerMoney -= 1000f;
            }

            
            
        }
    }

    public void ExitTheShop()
    {
        ShopMenu.SetActive(false);

        //locks the cursor
        Cursor.lockState = CursorLockMode.Locked;


    }

}
