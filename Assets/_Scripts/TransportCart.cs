using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportCart : MonoBehaviour
{

    public GameObject player;
    public bool inRange;

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
        if (inRange)
        {
            player.transform.parent = this.transform;
        }
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
