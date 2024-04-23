using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clicker : MonoBehaviour
{

    public GameObject canvasMain;
    public GameObject canvasDrum;


    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
            {

            // Whatever you want it to do.
            Debug.Log("Wow");
            canvasMain.SetActive(false);
            canvasDrum.SetActive(true);
        }
    }



}
