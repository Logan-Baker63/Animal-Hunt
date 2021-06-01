using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public int zoom = 20;
    public int normal = 60;
    public float smooth = 5;

    private bool isZoomed = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) //zooms camera on right click (when scoped)
        {
            isZoomed = true;
        }

        if (isZoomed) //zooms camera on right click (when scoped)
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
        }
        else //returns camera zoom to normal
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
        }

        //returns camera zoom to normal
        if (Input.GetMouseButtonUp(1))
        {
            isZoomed = false;
        }
    }

}
