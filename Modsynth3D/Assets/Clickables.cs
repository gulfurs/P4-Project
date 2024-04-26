    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

public class Clickables : MonoBehaviour {
    public Camera cam;
    public GameObject canvasMain;
    public GameObject canvasOther;
        
    // Called when the object is Left clicked
    public virtual void OnLeftClick()
    {
        //Virtue
    }

    // Called when the object is Right clicked
    public virtual void OnRightClick()
    {
        //Virtue
    }

    // Update is called once per frame
    void Update()   
    {   
        Ray originMouse = cam.ScreenPointToRay(Input.mousePosition);
            
        // Draw the ray in the murder scene
        Debug.DrawRay(originMouse.origin, originMouse.direction * 100, Color.red);


        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
                
            if (Physics.Raycast(originMouse, out hit))
            {
                //Check if ray hits clicker
                Clicker clickable = hit.collider.GetComponent<Clicker>();
                //Checks if it's clicker
                if (clickable != null)
                {
                    Debug.Log("Object clicked: " + hit.collider.gameObject.name);
                    OnLeftClick();
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                if (Physics.Raycast(originMouse, out hit))
                {
                    //Check if ray hits clicker
                    Clicker clickable = hit.collider.GetComponent<Clicker>();
                    //Checks if it's clicker
                    if (clickable != null)
                    {
                        OnRightClick();
                    }
                }
            }
        }
    }
}
