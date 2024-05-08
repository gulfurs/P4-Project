using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMan_buttons : MonoBehaviour
{
    private AudioSource[] audioSource;
    [SerializeField] AudioMixer audioMix;
    public Slider volumeSlider;
    public Slider frequencySlider;

    private float originalFrequency = 100f;

    void Start(){

        audioSource = FindObjectsOfType<AudioSource>();
        //volumeSlider.onValueChanged.AddListener(VolumeChange);
        frequencySlider.value = originalFrequency;
        frequencySlider.onValueChanged.AddListener(FrequencyChange);
        //frequencySlider.onValueChanged.AddListener(FrequencyChange);

    
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

    public void VolumeChange(){
        
        float volume = volumeSlider.value;
        audioMix.SetFloat("master", Mathf.Log10(volume)*20);

        /*float scaledVolume = volume / 100f;

        foreach (AudioSource source in audioSource){
            source.volume = scaledVolume;
        }*/
    }

    public void FrequencyChange()
    {
        float pitch = frequencySlider.value;
        audioMix.SetFloat("pitch", pitch);
        /*float scaledFrequency = frequency / 100f;

        foreach (AudioSource source in audioSource)
        {
            source.pitch = scaledFrequency;
        }*/
    }

    public void ResetFrequency()
    {
        frequencySlider.value = originalFrequency;
    }
}