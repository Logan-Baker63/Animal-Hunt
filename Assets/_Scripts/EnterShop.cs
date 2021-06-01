using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnterShop : MonoBehaviour
{

    public GameObject Scope;
    public GameObject MoneyDisplay;
    public GameObject ShopMenu;
    public GameObject BackgroundShopMenu;
    public RandomRabbitSpawn RandomRabbitSpawn;
    public SimpleMovement SimpleMovement;
    public ShootingControl ShootingControl;
    public GameManager GameManager;

    public GameObject buyTenMovementSpeedButton;
    public float buyTenMovementSpeedPrice;

    public GameObject movementSpeedButton;
    public float movementSpeedSellPrice;

    public GameObject buyTenIncreaseRabbitSellPriceButton;
    public float buyTenRabbitSellPriceIncrease;

    public GameObject increaseRabbitSellPriceButton;
    public float buyRabbitSellPriceIncrease;

    public GameObject buyTenIncreaseDeerSellPriceButton;
    public float buyTenDeerSellPriceIncrease;

    public GameObject increaseDeerSellPriceButton;
    public float buyDeerSellPriceIncrease;

    public GameObject buyTenIncreaseFoxSellPriceButton;
    public float buyTenFoxSellPriceIncrease;

    public GameObject increaseFoxSellPriceButton;
    public float buyFoxSellPriceIncrease;

    public AudioSource cashRegister;
    public AudioSource doorbell;

    public SellAnimal SellAnimal;

    public FlameThrower Flamethrower;
    public GameObject buyFlamethrowerButton;

    private void Start()
    {
        ShopMenu.SetActive(false);
        BackgroundShopMenu.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") //enter shop if player walks into doorway
        {
            EnterTheShop();
        }
    }

    void EnterTheShop()
    {
        doorbell.Play(); //set UI to shop menu and play doorbell noise

        ShootingControl.canShoot = false;
        SimpleMovement.canMove = false;

        //resets UI accordingly
        Scope.SetActive(false);
        BackgroundShopMenu.SetActive(true);
        ShopMenu.SetActive(true);
        MoneyDisplay.SetActive(true);

        //unlocks the cursor
        Cursor.lockState = CursorLockMode.None;

    }

    private void Update()
    {
        //sets text of button prices so they are always accurate
        buyTenMovementSpeedButton.GetComponent<TextMeshProUGUI>().text = "Buy 10 - $" + buyTenMovementSpeedPrice;
        buyTenIncreaseRabbitSellPriceButton.GetComponent<TextMeshProUGUI>().text = "Buy 10 - $" + buyTenRabbitSellPriceIncrease;
        buyTenIncreaseDeerSellPriceButton.GetComponent<TextMeshProUGUI>().text = "Buy 10 - $" + buyTenDeerSellPriceIncrease;
        buyTenIncreaseFoxSellPriceButton.GetComponent<TextMeshProUGUI>().text = "Buy 10 - $" + buyTenFoxSellPriceIncrease;
    }

    public void BuyFlamethrower()
    {
        if (GameManager.GetComponent<GameManager>().playerMoney >= 5000)
        {
            cashRegister.Play();
            GameManager.GetComponent<GameManager>().playerMoney -= 5000;
            Flamethrower.canFlamethrower = true;
            buyFlamethrowerButton.SetActive(false);

        }
    }

    public void BuyTenIncreaseMovementSpeed()
    {
        //increases player movement speed if they have the money and click the button 10 times
        if (GameManager.GetComponent<GameManager>().playerMoney >= buyTenMovementSpeedPrice)
        {
            for (int i = 0; i < 10; i++)
            {
                IncreaseMovementSpeed();

            }
        }
        
    }

    public void IncreaseMovementSpeed()
    {

        Debug.Log("Yo");
        
        //increases player movement speed if they have the money and click the button
        if (GameManager.GetComponent<GameManager>().playerMoney >= movementSpeedSellPrice)
        {
            Debug.Log("-Amount bought-");
            cashRegister.Play();
            SimpleMovement.originalPlayerSpeed += 0.5f;
            GameManager.GetComponent<GameManager>().playerMoney -= movementSpeedSellPrice;

            //increases price every time it is bought
            movementSpeedSellPrice *= 1.05f;
            movementSpeedSellPrice = Mathf.Round(movementSpeedSellPrice);
            movementSpeedButton.GetComponent<TextMeshProUGUI>().text = "Increase Movement Speed - $" + movementSpeedSellPrice;

            buyTenMovementSpeedPrice = buyTenMovementSpeedPrice * 1.05f;
            buyTenMovementSpeedPrice = Mathf.Round(buyTenMovementSpeedPrice);
        }
        
        
    }

    public void BuyTenIncreaseRabbitSellPrice()
    {
        //increases rabbit sell price whenn button is clicked and player has enough money 10 times
        if (GameManager.GetComponent<GameManager>().playerMoney >= buyTenRabbitSellPriceIncrease)
        {
            for (int i = 0; i < 10; i++)
            {
                IncreaseRabbitSellPrice();

            }
        }

    }

    public void IncreaseRabbitSellPrice()
    {
        //increases rabbit sell price whenn button is clicked and player has enough money
        if (GameManager.GetComponent<GameManager>().playerMoney >= buyRabbitSellPriceIncrease)
        {

            cashRegister.Play();
            GameManager.GetComponent<GameManager>().playerMoney -= buyRabbitSellPriceIncrease;
            SellAnimal.rabbitWorth *= 1.2f;
            SellAnimal.rabbitWorth = Mathf.Round(SellAnimal.rabbitWorth);
            buyRabbitSellPriceIncrease *= 1.2f;
            buyRabbitSellPriceIncrease = Mathf.Round(buyRabbitSellPriceIncrease);
            increaseRabbitSellPriceButton.GetComponent<TextMeshProUGUI>().text = "Increase Rabbit Sell Price - $" + buyRabbitSellPriceIncrease;

            buyTenRabbitSellPriceIncrease = buyTenRabbitSellPriceIncrease * 1.2f;
            buyTenRabbitSellPriceIncrease = Mathf.Round(buyTenRabbitSellPriceIncrease);
        }
    }

    public void BuyTenIncreaseDeerSellPrice()
    {
        //Increases deer sell price whenn button is clicked and player has enough money 10 times
        if (GameManager.GetComponent<GameManager>().playerMoney >= buyTenDeerSellPriceIncrease)
        {
            for (int i = 0; i < 10; i++)
            {
                IncreaseDeerSellPrice();

            }
        }

    }

    public void IncreaseDeerSellPrice()
    {
        //Increases deer sell price whenn button is clicked and player has enough money
        if (GameManager.GetComponent<GameManager>().playerMoney >= buyDeerSellPriceIncrease)
        {

            cashRegister.Play();
            GameManager.GetComponent<GameManager>().playerMoney -= buyDeerSellPriceIncrease;
            SellAnimal.deerWorth *= 1.2f;
            SellAnimal.deerWorth = Mathf.Round(SellAnimal.deerWorth);
            buyDeerSellPriceIncrease *= 1.2f;
            buyDeerSellPriceIncrease = Mathf.Round(buyDeerSellPriceIncrease);
            increaseDeerSellPriceButton.GetComponent<TextMeshProUGUI>().text = "Increase Deer Sell Price - $" + buyDeerSellPriceIncrease;

            buyTenDeerSellPriceIncrease = buyTenDeerSellPriceIncrease * 1.2f;
            buyTenDeerSellPriceIncrease = Mathf.Round(buyTenDeerSellPriceIncrease);
        }
    }

    public void BuyTenIncreaseFoxSellPrice()
    {
        //Increases fox sell price whenn button is clicked and player has enough money 10 times
        if (GameManager.GetComponent<GameManager>().playerMoney >= buyTenFoxSellPriceIncrease)
        {
            for (int i = 0; i < 10; i++)
            {
                IncreaseFoxSellPrice();

            }
        }

    }

    public void IncreaseFoxSellPrice()
    {
        //Increases fox sell price whenn button is clicked and player has enough money
        if (GameManager.GetComponent<GameManager>().playerMoney >= buyFoxSellPriceIncrease)
        {

            cashRegister.Play();
            GameManager.GetComponent<GameManager>().playerMoney -= buyFoxSellPriceIncrease;
            SellAnimal.foxWorth *= 1.2f;
            SellAnimal.foxWorth = Mathf.Round(SellAnimal.foxWorth);
            buyFoxSellPriceIncrease *= 1.2f;
            buyFoxSellPriceIncrease = Mathf.Round(buyFoxSellPriceIncrease);
            increaseFoxSellPriceButton.GetComponent<TextMeshProUGUI>().text = "Increase Fox Sell Price - $" + buyFoxSellPriceIncrease;

            buyTenFoxSellPriceIncrease = buyTenFoxSellPriceIncrease * 1.2f;
            buyTenFoxSellPriceIncrease = Mathf.Round(buyTenFoxSellPriceIncrease);
        }
    }

    public void ExitTheShop()
    {
        //hides shop UI and re-enters game
        SimpleMovement.canMove = true;
        ShootingControl.canShoot = true;

        doorbell.Play();
        BackgroundShopMenu.SetActive(false);
        ShopMenu.SetActive(false);

        //locks the cursor
        Cursor.lockState = CursorLockMode.Locked;


    }

}
