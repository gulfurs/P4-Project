using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Reaktion;

public class FIlter_man : MonoBehaviour
{
    public AudioHighPassFilter highPassFilter;
    public AudioLowPassFilter lowPassFilter;
    //public BandPassFilter bandPassFilter; 

    public Slider highPassSlider;
    public Slider lowPassSlider;
    public Slider bandPassSlider;

    public GameObject audioSourceObject;

    void Update()
    {
        // Update filter parameters based on slider values
        highPassFilter.cutoffFrequency = highPassSlider.value;
        lowPassFilter.cutoffFrequency = lowPassSlider.value;

        float bandPassCutoff = (highPassSlider.value + lowPassSlider.value) / 2f;
        
        // Update band-pass slider value (optional)
        bandPassSlider.value = bandPassCutoff;
    }

    public void ApplyFilters()
    {
        audioSourceObject.GetComponent<AudioSource>().Play();
    }
}
