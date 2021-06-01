using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FlameThrower : MonoBehaviour
{

    public GameObject flamethrowerCollider;
    public GameObject flamethrowerEffect;
    public bool canFlamethrower = false;
    public VisualEffect Flamethrower;
    
    // Start is called before the first frame update
    void Start()
    {
        Flamethrower.Stop();
        flamethrowerCollider.SetActive(false);
        flamethrowerEffect.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F) && canFlamethrower) //use flamethrower when holding 'f'
        {
            Flamethrower.Play();
            flamethrowerCollider.SetActive(true);
        }
        else
        {
            Flamethrower.Stop();
            flamethrowerCollider.SetActive(false);
        }
    }
}
