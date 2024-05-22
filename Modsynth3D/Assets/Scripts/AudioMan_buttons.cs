using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//CLASS FOR MANAGING MASTER SOUND
public class AudioMan_buttons : MonoBehaviour
{
    private AudioSource[] audioSource;
    [SerializeField] AudioMixer audioMix;
    public Slider volumeSlider;
    public Slider frequencySlider;

    //GET ALL AUDIOSOURCES
    void Start()
    {
        audioSource = FindObjectsOfType<AudioSource>();
    }

    //METHOD TO PAUSE ALL SOUNDS
    public void Pause()
    {
        foreach (AudioSource source in audioSource){
            source.Pause();
        }
    }

    //METHOD TO PLAY ALL SOUNDS
    public void Play()
    {
        foreach (AudioSource source in audioSource){
            source.Play();
        }
    }

    //METHOD FOR CHANGING VOLUME
    public void VolumeChange(){
        
        float volume = volumeSlider.value;
        audioMix.SetFloat("master", Mathf.Log10(volume)*20);
    }

    //METHOD FOR CHANGING PITCH
    public void FrequencyChange()
    {
        float pitch = frequencySlider.value;
        audioMix.SetFloat("pitch", pitch);
    }
}