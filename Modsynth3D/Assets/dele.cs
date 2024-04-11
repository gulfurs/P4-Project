using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dele : MonoBehaviour
{

    public LibPdInstance pdPatch;

    // Reference to the button UI component
    public Button button;

    void Start()
    {
        // Subscribe to the button click event
        button.onClick.AddListener(OnClick);
    }

    // Function to handle button click
    void OnClick()
    {
        // Send a bang to the PD patch when the button is clicked
        pdPatch.SendBang("triggerOn");
    }
}
