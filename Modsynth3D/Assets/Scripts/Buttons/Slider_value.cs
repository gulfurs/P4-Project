using UnityEngine;
using UnityEngine.UI;

public class Slider2Float : MonoBehaviour
{
    // The Pd patch we'll be communicating with.
    public LibPdInstance pdPatch;
    // Reference to the UI slider
    public Slider slider;

    void Update()
    {
        // Get the value of the UI slider
        float sliderValue = slider.value;
        //Debug.Log(sliderValue);
        // Send the slider value to the PD patch.
        // We can then use the SendFloat() function to send our float value to
        // that named receive object.
        pdPatch.SendFloat("sliderValue", sliderValue);
    }
}
