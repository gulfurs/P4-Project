using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Note : MonoBehaviour
{

    public GameObject objectToToggle;
    public GameObject oToggle;


    public void SetNote()
    {


        objectToToggle.SetActive(!objectToToggle.activeSelf);
        oToggle.SetActive(!oToggle.activeSelf);
        
    }
}
