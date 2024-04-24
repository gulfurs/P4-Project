using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScrjpt : MonoBehaviour
{
    
    void Update()
    {
        
       if (Input.GetKeyDown(KeyCode.E))
            {

            DrumManager.PlaySound();
            Debug.Log("Hey");

        }
            
    }
}
