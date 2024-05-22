using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INTERFACE FOR CLICKABLE OBJECTS
public interface IClickable
{
    // METHOD FOR LEFT CLICK
    void OnLeftClick();

    //METHOD FOR RIGHT CLICK
    void OnRightClick();
}

//CLASS FOR MAKING BLOCKS CLICKABLE
public class Clickables : MonoBehaviour {

    private Camera cam;
    
     void Start() 
    {
        //SET CAMERA TO MAIN CAMERA
        cam = Camera.main;
    }
    
    void Update()
    {   
        // RAY GETS SEND OUT FROM MOUSE POSITION
        Ray originMouse = cam.ScreenPointToRay(Input.mousePosition);
            
        // DRAW RAY IN INSPECTOR
        Debug.DrawRay(originMouse.origin, originMouse.direction * 100, Color.red);

        // IF LEFT CLICK? SEND RAY THAT HITS BLOCK
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(originMouse, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;

                Clicker clickable = hitObject.GetComponent<Clicker>();
                
                IClickable clicky = hitObject.GetComponent<IClickable>();

                if (clickable != null)
                {
                    Debug.Log("Object Left clicked: " + hit.collider.gameObject.name);
                    clicky.OnLeftClick();
                }
            }
        }

        // IF RIGHT MOUSE? SEND RAY THAT HITS BLOCK
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(originMouse, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;

                Clicker clickable = hit.collider.GetComponent<Clicker>();
                
                IClickable clicky = hitObject.GetComponent<IClickable>();
                if (clickable != null)
                {
                    Debug.Log("Object Right clicked: " + hit.collider.gameObject.name);
                    clicky.OnRightClick();
                }
            }
        }
    }
}
