using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FIlter_man : MonoBehaviour
{
    public AudioLowPassFilter lowPassFilter;
    public AudioHighPassFilter highPassFilter;
    //public AudioBandPassFilter bandPassFilter;

    public Slider lowPassSlider;
    public Slider highPassSlider;
    public Slider bandPassSlider;

    void Update()
    {
        // Update filter parameters based on slider values
        lowPassFilter.cutoffFrequency = lowPassSlider.value;
        highPassFilter.cutoffFrequency = highPassSlider.value;
       // bandPassFilter.centerFrequency = bandPassSlider.value;
    }
}
