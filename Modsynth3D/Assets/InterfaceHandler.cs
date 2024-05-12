using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceHandler : MonoBehaviour
{
    public Camera mainCamera;
    private GameObject howToTab;
    public bool ok;
    private Vector3 originalCameraPosition;
    private Vector3 elevatedCameraPosition;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        howToTab = GameObject.Find("HowTo");

        // Store the original camera position
        originalCameraPosition = mainCamera.transform.position;
        // Calculate the elevated camera position
        elevatedCameraPosition = originalCameraPosition + Vector3.up * 10f; 
    }

    void Update()
    {
        ok = CheckChild();
        if (CheckChild())
        {
            if (howToTab != null)
            {
                howToTab.SetActive(false);
            }
            mainCamera.transform.position = elevatedCameraPosition;
            mainCamera.cullingMask = 1 << LayerMask.NameToLayer("UI");
        }
        else
        {
            if (howToTab != null)
            {
                howToTab.SetActive(true);
            }
            mainCamera.transform.position = originalCameraPosition;
            mainCamera.cullingMask = -1;
        }
    }

    // Check if a child is active.

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