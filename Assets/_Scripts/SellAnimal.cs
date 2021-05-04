using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellAnimal : MonoBehaviour
{

    public float moneyWorth = 0f;
    public GameObject moneyAmountPreviewText;
    public GameObject buttonPressPrompt;
    public GameObject gameManager;

    public List<GameObject> animalsBeingSold = new List<GameObject>();

    public bool canSell = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DeadRabbit")
        {
            moneyWorth += 100f;
            animalsBeingSold.Add(other.gameObject);
        }
        else if (other.tag == "DeadDeer")
        {
            moneyWorth += 250f;
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
            moneyWorth -= 100f;
            animalsBeingSold.Remove(other.gameObject);
        }
        else if (other.tag == "DeadDeer")
        {
            moneyWorth -= 250f;
            animalsBeingSold.Remove(other.gameObject);
        }



    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moneyAmountPreviewText.GetComponent<TextMesh>().text = ("$" + moneyWorth);

        if (moneyWorth > 0f)
        {
            buttonPressPrompt.SetActive(true);
            canSell = true;
        }
        else
        {
            buttonPressPrompt.SetActive(false);
            canSell = false;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (canSell == true)
            {

                canSell = false;
                gameManager.GetComponent<GameManager>().playerMoney += moneyWorth;

                for (int i = 0; i < animalsBeingSold.Count; i++)
                {
                    GameObject.Destroy(animalsBeingSold[i]);
                }

                


                moneyWorth = 0;

                animalsBeingSold.Clear();
            }


        }

    }
}
