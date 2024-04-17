using UnityEngine;
using UnityEngine.UI;

public class Slider2Float : MonoBehaviour
{
    // The Pd patch we'll be communicating with.
    public LibPdInstance pdPatch;
    // Reference to the UI slider
    public Slider slider;

    private float previousSliderValue;

    void Start()
    {
        // Initialize previousSliderValue with the initial value of the slider
        previousSliderValue = slider.value;
        // Add listener for value change event
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    void OnSliderValueChanged(float newValue)
    {
        // Check if the new value is different from the previous one
        if (newValue != previousSliderValue)
        {
            // Update the previousSliderValue
            previousSliderValue = newValue;
            // Send the new slider value to the PD patch
            pdPatch.SendFloat("sliderValue", newValue);

            
        }
    }

    // Remove the Update method as it's no longer needed for sending slider values
}
