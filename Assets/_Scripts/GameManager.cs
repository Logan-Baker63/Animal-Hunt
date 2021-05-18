using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject Scope;
    public GameObject Gun;
    public GameObject moneyDisplay;
    public float playerMoney;

    public GameObject mainMenu;
    public GameObject pauseMenu;

    public bool isTitlePage = true;

    public Vector3 originalGunPosition;
    public float originalGunRotation;

    public Camera TitlePageCamera;
    public Camera MainCamera;

    public AudioSource ambience;

    public ShootingControl ShootingControl;
    public SimpleMovement SimpleMovement;

    // Start is called before the first frame update
    void Start()
    {
        Scope.SetActive(false);
        moneyDisplay.SetActive(true);

        originalGunPosition = Gun.transform.localPosition; //sets original gun positions so its possible to transfer back to later on
        originalGunRotation = Gun.transform.localEulerAngles.x;

        TitlePageCamera.depth = 0; //sets title page camera to main camera
        MainCamera.depth = -1;
        mainMenu.SetActive(true); //displays main menu and hides other UI
        pauseMenu.SetActive(false);

        ambience.Play(); //Plays ambience on loop

}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1)) //detects holding right click
        {
            Scope.SetActive(true); //shows scope overlay and moves gun to centre of character
            moneyDisplay.SetActive(false);
            Gun.transform.localPosition = new Vector3(0f, -0.15f, 0f);
            Gun.transform.localEulerAngles = new Vector3(0.8f, 180f, 0f);
        }
        else
        {
            Scope.SetActive(false); //hides scope and moves gun to normal position
            moneyDisplay.SetActive(true);
            Gun.transform.localPosition = originalGunPosition;
            Gun.transform.localEulerAngles = new Vector3(originalGunRotation, 180f, 0);
        }

        moneyDisplay.GetComponent<TextMeshProUGUI>().text = ("$" + playerMoney.ToString()); //adds money to player

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None; //opens pause menu
            pauseMenu.SetActive(true);
            ShootingControl.canShoot = false;
            SimpleMovement.canMove = false;
        }

    }

    public void ChangeCameraView()
    {
        if (isTitlePage) //sets main camera to main camera
        {
            TitlePageCamera.depth = -1;
            MainCamera.depth = 0;
            isTitlePage = false;
            Cursor.lockState = CursorLockMode.Locked;
            mainMenu.SetActive(false);
;        }
        else //sets title page camera to main camera
        {
            TitlePageCamera.depth = 0;
            MainCamera.depth = -1;
            isTitlePage = true;
            Cursor.lockState = CursorLockMode.None;
            mainMenu.SetActive(true);
        }
    }

    public void Continue()
    {
        pauseMenu.SetActive(false); //hides UI and returns to game
        Cursor.lockState = CursorLockMode.Locked;
        ShootingControl.canShoot = true;
        SimpleMovement.canMove = true;
    }

    public void Play()
    {
        ChangeCameraView(); //hides UI and starts game
        ShootingControl.canShoot = true;
        SimpleMovement.canMove = true;
    }

    public void MainMenu()
    {
        pauseMenu.SetActive(false); //hides other UI and displays main menu
        ShootingControl.canShoot = false;
        SimpleMovement.canMove = false;

        ChangeCameraView();
    }

    public void Options()
    {

    }

    public void RefreshBugs()
    {

    }

    public void ExitApplication()
    {
        Application.Quit(); //quits application
    }

}
