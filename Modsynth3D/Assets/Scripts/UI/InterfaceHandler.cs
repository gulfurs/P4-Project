using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CLASS TO HIDE BLOCKS WHEN AN INTERFACE IS PRESENT
public class InterfaceHandler : MonoBehaviour
{
    public Camera mainCamera;
    private GameObject howToTab;
    public bool ok;
    private Vector3 originalPos;
    private Vector3 elevatedPos;

    void Start()
    {   
        // GET MAIN CAMERA
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        //FIND HOWTO TAB SO IT CAN BE ENABLED/DISABLED EVENTUALLY.
        howToTab = GameObject.Find("HowTo");

        // STORE ORIGINAL POSITION
        originalPos = mainCamera.transform.position;
        // ELEVATED CAMERA POSITION
        elevatedPos = originalPos + Vector3.up * 10f; 
    }

    void Update()
    {
        ok = CheckChild();

        // IF THERE IS ACTIVE CHILDREN ELEVATE CAMERA POSITION
        if (CheckChild())
        {
            if (howToTab != null)
            {
                howToTab.SetActive(false);
            }
            mainCamera.transform.position = elevatedPos;
            mainCamera.cullingMask = 1 << LayerMask.NameToLayer("UI");
        }
        else
        {
            if (howToTab != null)
            {
                howToTab.SetActive(true);
            }
            mainCamera.transform.position = originalPos;
            mainCamera.cullingMask = -1;
        }
    }

    // CHECK FOR ACTIVE CHILDREN OBJECTS.
    public bool CheckChild()
    {
        Transform parent = transform;
        foreach (Transform child in parent)
        {
            if (child.gameObject.activeSelf)
                return true;
        }
        return false;
    }
}