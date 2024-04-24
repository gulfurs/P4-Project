using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeReverb : MonoBehaviour
{

    // Reference to the AudioReverbFilter component
    private AudioReverbFilter reverbFilter;


    public Slider knobSlider; // Reference to the knob slider in the Unity Inspector
    public float knobValue; // Public variable to store the knob value



    void Start()
    {
        // Get the AudioReverbFilter component attached to this GameObject
        reverbFilter = GetComponent<AudioReverbFilter>();

        if (reverbFilter == null)
        {
            // If AudioReverbFilter is not found, you may want to handle this case
            Debug.LogError("AudioReverbFilter component not found!");
        }
    }

    // Function to set the reverb preset
    public void SetReverbPreset(AudioReverbPreset preset)
    {
        if (reverbFilter != null)
        {
            // Set the reverb preset
            reverbFilter.reverbPreset = preset;
        }
        else
        {
            Debug.LogError("AudioReverbFilter component is not available!");
        }
    }

    
    public void SetReverbCave()

    {
        SetReverbPreset(AudioReverbPreset.Cave);

    }

    public void SetReverbHallway()

    {
       SetReverbPreset(AudioReverbPreset.Hallway);

    }


    public void SetReverbForest()

    {
        SetReverbPreset(AudioReverbPreset.Forest);

    }

    public void SetReverbUser()

    {
        SetReverbPreset(AudioReverbPreset.User);
    }

    
    void Update()
    {

        knobValue = knobSlider.value;
        reverbFilter.dryLevel = knobValue;
    }



}
