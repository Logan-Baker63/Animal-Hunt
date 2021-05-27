using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FlameThrower : MonoBehaviour
{

    public VisualEffect Flamethrower;
    
    // Start is called before the first frame update
    void Start()
    {
        Flamethrower.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            Flamethrower.Play();
        }
        else
        {
            Flamethrower.Stop();
        }
    }
}
