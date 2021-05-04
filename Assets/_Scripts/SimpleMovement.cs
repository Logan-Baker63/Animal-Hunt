using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    CharacterController controller;

    public float playerSpeed = 12f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private Vector3 playerVelocity;
    public bool groundedPlayer;

    public Transform MainCameraTransform;

   

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {

        groundedPlayer = controller.isGrounded;

        //user directional inputs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical"); 
        
        //locks cursor/hides it
        Cursor.lockState = CursorLockMode.Locked;

        //sprinting on left shift
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = 15f;
        }
        else
        {
            playerSpeed = 12f;
        }

        //creates a local direction from the x and z inputs
        Vector3 MovementDirection = transform.right * x + transform.forward * z;

        //move the character forwards and backwards using 'w' and 's'
        controller.Move(Vector3.Scale(MovementDirection * playerSpeed * Time.deltaTime, new Vector3(1, 0, 1)));

        //turn the character left and right from using 'a' and 'd'
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));

        //move the camera up and down as the player moves their mouse up and downn on the y axis
        MainCameraTransform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0));

        
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }


        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);


    }
}
