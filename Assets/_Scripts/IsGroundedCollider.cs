using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundedCollider : MonoBehaviour
{

    public SimpleMovement SimpleMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Structure")
        {
            SimpleMovement.groundedPlayer = true;
            Debug.Log("Landed");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Structure")
        {
            SimpleMovement.groundedPlayer = false;
            Debug.Log("Jumped");
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
