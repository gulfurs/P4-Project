using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioMan_buttons : MonoBehaviour
{
    private AudioSource[] audioSource;
    public Slider volumeSlider;
    public Slider frequencySlider;

    private float originalFrequency = 50f;

    void Start(){

        audioSource = FindObjectsOfType<AudioSource>();
        //volumeSlider.onValueChanged.AddListener(VolumeChange);
        frequencySlider.value = originalFrequency;
        frequencySlider.onValueChanged.AddListener(FrequencyChange);

    
    }
    public void Pause(){

        foreach (AudioSource source in audioSource){
            source.Pause();
        }
    }

     public void Play(){

        foreach (AudioSource source in audioSource){
            source.UnPause();
        }
    }

    /*void VolumeChange(float volume){
        
        float scaledVolume = volume / 100f;

        foreach (AudioSource source in audioSource){
            source.volume = scaledVolume;
        }
    }*/

     void FrequencyChange(float frequency)
    {
        float scaledFrequency = frequency / 100f;

        foreach (AudioSource source in audioSource)
        {
            source.pitch = scaledFrequency;
        }
    }

    public void ResetFrequency()
    {
        frequencySlider.value = originalFrequency;
    }
}