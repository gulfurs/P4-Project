using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clicker : MonoBehaviour
{

    public GameObject canvasMain;
    public GameObject canvasOther;


    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
            {

            // Whatever you want it to do.
            Debug.Log("Wow");
            canvasMain.SetActive(false);
            canvasOther.SetActive(true);
        }
    }



}
