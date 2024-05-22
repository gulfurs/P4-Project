using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_button_only_on : MonoBehaviour
{
    public Slider slider;
    public LibPdInstance pdPatch;

    //Reference to the button UI component
    public Button button;

    void Start()
    {
        // Subscribe to the button click event
        button.onClick.AddListener(OnClick);
    }

    // Function to handle button click
    void OnClick()
    {
        float sliderValue = slider.value;
        pdPatch.SendFloat("sliderValue", sliderValue);
        pdPatch.SendBang("triggerOn");
    }
}
