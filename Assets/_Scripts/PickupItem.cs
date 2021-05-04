using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    Transform theDest;

    public bool inRange = false;
    public bool isPickedUp = false;
    public bool handcartInRange = false;

    public bool inCart = false;

    public float targetScale = 0.3f;
    public float shrinkSpeed = 2000f;

    public float amountOfRabbitsInCart = 0;

    public GameObject leftClickPrompt;

    public GameObject player;

    public Vector3 originalScale;

    private void Start()
    {
        theDest = GameObject.Find("Grabber").transform;
        leftClickPrompt = GameObject.FindGameObjectWithTag("LeftClick").gameObject;
        player = GameObject.FindGameObjectWithTag("Player").gameObject;

        originalScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            inRange = true;
        }

        if (other.tag == "Cart")
        {
            handcartInRange = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
        }

        if (other.tag == "Cart")
        {
            handcartInRange = false;
        }

    }

    private void Update()
    {
        
        
        
        if ((gameObject.tag == "DeadRabbit" || gameObject.tag == "DeadDeer") && inRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inCart = false;
                
                GetComponent<Rigidbody>().useGravity = false;

                this.transform.position = theDest.position;

                GetComponent<Rigidbody>().isKinematic = false;

                this.transform.parent = null;

                gameObject.transform.localScale = originalScale;

                this.transform.parent = GameObject.Find("Grabber").transform;
                isPickedUp = true;


                player.GetComponent<ShootingControl>().canShoot = false;

            }
        }

        if (isPickedUp && handcartInRange)
        {

            leftClickPrompt.GetComponent<TextMesh>().text = "Left Click while holding carcass to store for transport";

            if (Input.GetMouseButtonDown(0))
            {
                inCart = true;
                
                this.transform.parent = GameObject.Find("Handcart").transform;
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().isKinematic = true;

                gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, new Vector3(targetScale, targetScale, targetScale), Time.deltaTime * shrinkSpeed);

                if (amountOfRabbitsInCart == 0)
                {
                    gameObject.transform.position = new Vector3(-0.987f, 2.466f, -56.692f);
                    amountOfRabbitsInCart++;
                }
                else if (amountOfRabbitsInCart == 1)
                {
                    gameObject.transform.position = new Vector3(-0.987f, 2.466f, -56.692f);
                    amountOfRabbitsInCart++;
                }
                else if (amountOfRabbitsInCart == 2)
                {
                    gameObject.transform.position = new Vector3(-0.987f, 2.466f, -56.692f);
                    amountOfRabbitsInCart++;
                }
                else if (amountOfRabbitsInCart == 3)
                {
                    gameObject.transform.position = new Vector3(-0.987f, 2.466f, -56.692f);
                    amountOfRabbitsInCart++;
                }
                else if (amountOfRabbitsInCart == 4)
                {
                    gameObject.transform.position = new Vector3(-0.987f, 2.466f, -56.692f);
                    amountOfRabbitsInCart = 0;
                }

                leftClickPrompt.GetComponent<TextMesh>().text = "";

            }

            

        }
        else
        {
            leftClickPrompt.GetComponent<TextMesh>().text = "";
        }

        if ((gameObject.tag == "DeadRabbit" || gameObject.tag == "DeadDeer") && transform.position.y < 0) {
            gameObject.transform.Translate(new Vector3(0, 10, 0));
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            
            if (inCart == false) 
            {
                this.transform.parent = null;
            }

            GetComponent<Rigidbody>().useGravity = true;
            isPickedUp = false;


            player.GetComponent<ShootingControl>().canShoot = true;
        }

    }

}
