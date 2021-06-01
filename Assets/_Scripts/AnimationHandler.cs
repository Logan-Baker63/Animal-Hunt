using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{

    Animator anim;

    public Vector3 lastPosition;
    //public Transform rabbitTransform;
    public bool isMoving;
    DieWhenShot DieWhenShot;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        DieWhenShot = GetComponent<DieWhenShot>();

        lastPosition = transform.position;
        isMoving = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != lastPosition) //check if animal is moving
            isMoving = true;
        else
            isMoving = false;

        lastPosition = transform.position; 

        if (DieWhenShot.isDead == false) //if animal is dead and not moving set it to dead animation
        {
            if (isMoving == true)
            {
                anim.SetInteger("AnimIndex", 1);


            }
            else
            {
                anim.SetInteger("AnimIndex", 0);

            }
        }

    }
}
