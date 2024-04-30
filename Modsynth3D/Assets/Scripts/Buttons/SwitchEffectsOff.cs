using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchEffectsOff : MonoBehaviour
{


    private bool TurnedOn;
    AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

    
    public void SwitchReverb()
    {

        // Find all audio sources in the scene

        if (TurnedOn == false)
        {

            foreach (AudioSource audioSource in allAudioSources)
            {
                // Disable all audio filters attached to the audio source
                audioSource.bypassEffects = true;
                audioSource.bypassListenerEffects = true;
                audioSource.bypassReverbZones = true;
                TurnedOn = true;
            }


        }
        else if (TurnedOn == true)
        {
            foreach (AudioSource audioSource in allAudioSources)
            {
                audioSource.bypassEffects = false;
                audioSource.bypassListenerEffects = false;
                audioSource.bypassReverbZones = false;
                TurnedOn = false;
            }

            // Disable all audio filters attached to the audio source


        }



    }

    public void Test()
    {

    }

}
