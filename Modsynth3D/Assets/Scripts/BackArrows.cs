using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackArrows : MonoBehaviour
{
    public GameObject canvasMain;
    public GameObject canvasDrum;


    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {

            // Whatever you want it to do.
            Debug.Log("Wow");
            canvasMain.SetActive(true);
            canvasDrum.SetActive(false);
        }
    }

}
