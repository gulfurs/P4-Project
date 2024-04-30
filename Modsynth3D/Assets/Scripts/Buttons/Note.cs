using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{

    public GameObject objectToToggle;


    public void SetNote()
    {


        objectToToggle.SetActive(!objectToToggle.activeSelf);
        
    }
}
