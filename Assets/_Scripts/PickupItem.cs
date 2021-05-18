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
    public float targetScaleDeer = 0.6f;
    public float shrinkSpeed = 2000f;
    public GameObject leftClickPrompt;

    public GameObject player;

    public Vector3 originalScale;

    GameObject transportCart;

    Transform AnimalSocket1;

    private void Start()
    {

        //sets variable values
        theDest = GameObject.Find("Grabber").transform;
        leftClickPrompt = GameObject.FindGameObjectWithTag("LeftClick").gameObject;
        player = GameObject.FindGameObjectWithTag("Player").gameObject;

        originalScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);

        transportCart = GameObject.FindGameObjectWithTag("Cart").gameObject;

        AnimalSocket1 = GameObject.Find("Animal Socket 1").transform;

    }

    private void OnTriggerEnter(Collider other)
    {
        
        //detects when player is in radius
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
        //detects when player leaves radius
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
        
        
        //ensures you cannot pick up animal while using transport cart
        if (transportCart.GetComponent<TransportCart>().isParented)
        {

        }
        else
        {
            if (inRange == true)
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
            //storing carcasses in cart
            if (isPickedUp && handcartInRange)
            {

                AnimalSocket1 = GameObject.Find("Animal Socket 1").transform;

                //display message appear when in range
                leftClickPrompt.GetComponent<TextMesh>().text = "Left Click while holding carcass to store for transport";

                //on left click place carcass in cart
                if (Input.GetMouseButtonDown(0))
                {
                    inCart = true;

                    this.transform.parent = GameObject.Find("Handcart").transform; //sets parent of animal to cart
                    GetComponent<Rigidbody>().useGravity = false;
                    GetComponent<Rigidbody>().isKinematic = true;

                    if (tag == "DeadRabbit" || tag == "DeadFox")
                    {
                        //shrinks the rabbit when in the cart to make it look neater
                        gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, new Vector3(targetScale, targetScale, targetScale), Time.deltaTime * shrinkSpeed);
                    }
                    else if (tag == "DeadDeer")
                    {
                        gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, new Vector3(targetScaleDeer, targetScaleDeer, targetScaleDeer), Time.deltaTime * shrinkSpeed);
                    }
                    
                    

                    gameObject.transform.position = AnimalSocket1.position;
                    

                    leftClickPrompt.GetComponent<TextMesh>().text = ""; //removes display message after putting animal in cart

                }



            }
            else
            {
                leftClickPrompt.GetComponent<TextMesh>().text = ""; //removes display message
            }

            if (transform.position.y < 0)
            {
                gameObject.transform.Translate(new Vector3(0, 5, 0)); //TEMPERARY - bug makes animal fall through floor when killed, this sets its position in the sky so it falls on land
            }

            if (Input.GetKeyUp(KeyCode.E)) //drops held animals when left click is released
            {

                //resets parenting of animal
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

}
