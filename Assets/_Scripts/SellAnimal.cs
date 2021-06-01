using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellAnimal : MonoBehaviour
{

    public float moneyWorth = 0f;
    public GameObject moneyAmountPreviewText;
    public GameObject buttonPressPrompt;
    public GameObject gameManager;

    public float rabbitWorth = 100f;
    public float deerWorth = 250f;
    public float foxWorth = 550f;

    public ShootingControl ShootingControl;

    public bool ezMoney = false;

    public List<GameObject> animalsBeingSold = new List<GameObject>();

    public bool canSell = false;

    public AudioSource m_audioSource;

    private void OnTriggerEnter(Collider other) //checks what animals are on the table and adds their value up to then display
    {
        if (other.tag == "DeadRabbit")
        {
            moneyWorth += rabbitWorth;
            //adds the animal on the bench to a list
            animalsBeingSold.Add(other.gameObject);
        }
        else if (other.tag == "DeadDeer")
        {
            if (ezMoney)
            {
                moneyWorth += 999999f;
            }
            else
            {
                moneyWorth += deerWorth;
            }
                
            //adds the animal on the bench to a list
            animalsBeingSold.Add(other.gameObject);

        }
        else if (other.tag == "DeadFox")
        {
            moneyWorth += foxWorth;
            //adds the animal on the bench to a list
            animalsBeingSold.Add(other.gameObject);
        }

        if (other.tag == "Player")
        {
            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "DeadRabbit")
        {
            moneyWorth -= rabbitWorth;
            //removes the animal from the list
            animalsBeingSold.Remove(other.gameObject);
        }
        else if (other.tag == "DeadDeer")
        {
            moneyWorth -= deerWorth;
            //removes the animal from the list
            animalsBeingSold.Remove(other.gameObject);
        }
        else if (other.tag == "DeadFox")
        {
            moneyWorth -= foxWorth;
            //removes the animal from the list
            animalsBeingSold.Add(other.gameObject);
        }



    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //displays the worth of the animal carcasses
        moneyAmountPreviewText.GetComponent<TextMesh>().text = ("$" + moneyWorth); 

        if (moneyWorth > 0f) //displays 'press q to sell' prompt and allows player to sell
        {
            buttonPressPrompt.SetActive(true);
            canSell = true;
        }
        else
        {
            buttonPressPrompt.SetActive(false);
            canSell = false;
        }

        if (Input.GetKeyDown(KeyCode.Q)) //when q is pressed
        {
            if (canSell == true) //check if the player is allowed to sell
            {

                ShootingControl.canShoot = true; //enables shooting (because of bug that needs refreshing)

                //play cash register sound and give player the money for the animals
                m_audioSource.Play();
                canSell = false;
                gameManager.GetComponent<GameManager>().playerMoney += moneyWorth;

                //destroys the animals being sold
                for (int i = 0; i < animalsBeingSold.Count; i++)
                {
                    GameObject.Destroy(animalsBeingSold[i]);
                }

                


                moneyWorth = 0; //resets the value of money when no animals are present to prevent bugs/glitches

                animalsBeingSold.Clear(); //clears the list of animals being sold just in case
            }


        }

    }
}
