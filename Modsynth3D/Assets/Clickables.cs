using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IClickable
{
    void OnLeftClick();
    void OnRightClick();
}

public class Clickables : MonoBehaviour {
    private Camera cam;
        
    public virtual void Start() {
        cam = Camera.main;
    }
    
    // Update is called once per frame
    public virtual void Update()   
    {   
        Ray originMouse = cam.ScreenPointToRay(Input.mousePosition);
            
        // Draw the ray in the murder scene
        Debug.DrawRay(originMouse.origin, originMouse.direction * 100, Color.red);


        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit[] hits = Physics.RaycastAll(originMouse);
                
            foreach (RaycastHit hit in hits)
            {
                GameObject hitObject = hit.collider.gameObject;
                //Check if ray hits clicker
                Clicker clickable = hitObject.GetComponent<Clicker>();
                //Checks if it's clicker

                IClickable clicky = hitObject.GetComponent<IClickable>();

                if (clickable != null)
                {
                    Debug.Log("Object Left clicked: " + hit.collider.gameObject.name);
                    clicky.OnLeftClick();
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
            {
                RaycastHit[] hits = Physics.RaycastAll(originMouse);

                foreach (RaycastHit hit in hits)
                {
                    GameObject hitObject = hit.collider.gameObject;
                    //Check if ray hits clicker
                    Clicker clickable = hit.collider.GetComponent<Clicker>();
                    //Checks if it's clicker
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
