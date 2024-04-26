using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    public GameObject canvasMain;
    public GameObject canvasOther;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Cast a ray from mouse
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the ray hit the object
                if (hit.collider.gameObject == gameObject)
                {
                    // If the clicked object is this block
                    Debug.Log("Block clicked!");
                    
                    // Now you can do something like showing a different canvas
                    if (canvasMain != null)
                        canvasMain.SetActive(false);
                    if (canvasOther != null)
                        canvasOther.SetActive(true);
                }
            }
        }
    }
}
