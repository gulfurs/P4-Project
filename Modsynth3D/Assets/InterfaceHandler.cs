using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceHandler : MonoBehaviour
{
    public Camera mainCamera;
    
    void Start() {
    if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        if (gameObject.activeSelf)
        {
            //CullingMask UI
            mainCamera.cullingMask = 1 << LayerMask.NameToLayer("UI");
        }
    }
}
