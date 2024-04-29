using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudio : MonoBehaviour
{
    
    public AudioSource audioSource; 

    public AudioClip audioClip;  


    void Start()
    {
    audioSource = GetComponent<AudioSource>();


    if (audioClip == null)
        {
            GetComponent<UnityEngine.UI.Button>().interactable = false;
        }

    }
    public void PlayAudio()
    {
        audioSource.clip = audioClip;
        
        audioSource.Play();
    }
}
