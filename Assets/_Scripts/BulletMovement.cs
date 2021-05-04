using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public float ConstantSpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move the bullet forward
        transform.Translate(new Vector3(0, 0, ConstantSpeed * Time.deltaTime));
    }
}
