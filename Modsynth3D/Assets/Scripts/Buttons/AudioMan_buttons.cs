using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioMan_buttons : MonoBehaviour
{
    private AudioSource[] audioSource;
    public Slider volumeSlider;
    public Slider frequencySlider;

    void Start(){

        audioSource = FindObjectsOfType<AudioSource>();
        volumeSlider.onValueChanged.AddListener(VolumeChange);
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
     public void Revert(){

        foreach (AudioSource source in audioSource){
            source.Play();
        }
    }

    void VolumeChange(float volume){
        
        float scaledVolume = volume / 100f;

        foreach (AudioSource source in audioSource){
            source.volume = scaledVolume;
        }
    }

     void FrequencyChange(float frequency)
    {
        float scaledFrequency = frequency / 100f;

        foreach (AudioSource source in audioSource)
        {
            source.pitch = scaledFrequency;
        }
    }
}