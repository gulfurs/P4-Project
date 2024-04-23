using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FIlter_man : MonoBehaviour
{
    public AudioHighPassFilter highPassFilter;
    public AudioLowPassFilter lowPassFilter;

    public Slider highPassSlider;
    public Slider lowPassSlider;

    public GameObject audioSourceObject;

    void Update()
    {
        // Update filter parameters based on slider values
        highPassFilter.cutoffFrequency = highPassSlider.value;
        lowPassFilter.cutoffFrequency = lowPassSlider.value;
    }

    public void ApplyFilters()
    {
        audioSourceObject.GetComponent<AudioSource>().Play();
    }
}
