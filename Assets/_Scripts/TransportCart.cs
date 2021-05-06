using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportCart : MonoBehaviour
{

    public GameObject player;
    GameObject middleClickToControl;
    public bool inRange;

    public bool isParented = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
        }
    }

    void ControlCart()
    {
        this.transform.parent = player.transform;
        this.transform.localPosition = new Vector3(-0.1665162f, -0.9611177f, -1.445516f);
        this.transform.localEulerAngles = new Vector3(-0.431f, 95.094f, -22.393f);
        isParented = true;
        player.GetComponent<SimpleMovement>().playerSpeed = 8; //doesnt work due to movement script constantly setting speed to 12

    }

    void ExitCartControl()
    {
        this.transform.parent = null;
        isParented = false;
        player.GetComponent<SimpleMovement>().playerSpeed = 12; //doesnt work due to movement script constantly setting speed to 12
    }

    // Start is called before the first frame update
    void Start()
    {
        middleClickToControl = GameObject.FindGameObjectWithTag("MiddleClick");
    }

    // Update is called once per frame
    void Update()
    {
        
        

        if (isParented == false)
        {
            if (inRange == true)
            {

                

                if (Input.GetMouseButtonDown(2))
                {
                    ControlCart();
                    middleClickToControl.SetActive(false);
                }
                else
                {
                    middleClickToControl.SetActive(true);
                }


            }
            else
            {
                middleClickToControl.SetActive(false);



            }
        }
        else
        {
            middleClickToControl.SetActive(false);

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                ExitCartControl();
            }

        }
        
        
    }
}
