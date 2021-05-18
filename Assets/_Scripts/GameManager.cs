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

    public Vector3 originalGunPosition;
    public float originalGunRotation;

    

    // Start is called before the first frame update
    void Start()
    {
        Scope.SetActive(false);
        moneyDisplay.SetActive(true);

        originalGunPosition = Gun.transform.localPosition;
        originalGunRotation = Gun.transform.localEulerAngles.x;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Scope.SetActive(true);
            moneyDisplay.SetActive(false);
            Gun.transform.localPosition = new Vector3(0f, -0.15f, 0f);
            Gun.transform.localEulerAngles = new Vector3(0.8f, 180f, 0f);
        }
        else
        {
            Scope.SetActive(false);
            moneyDisplay.SetActive(true);
            Gun.transform.localPosition = originalGunPosition;
            Gun.transform.localEulerAngles = new Vector3(originalGunRotation, 180f, 0);
        }

        moneyDisplay.GetComponent<TextMeshProUGUI>().text = ("$" + playerMoney.ToString());

    }

    

}
