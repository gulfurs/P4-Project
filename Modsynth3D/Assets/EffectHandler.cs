using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectHandler : MonoBehaviour
{
    public GameObject myBlock;

    private AudioEchoFilter echoFilter;
    private AudioDistortionFilter distortionFilter;
    private AudioReverbFilter reverbFilter;

    public Slider distortionSlider;
    public Slider delaySlider;

    public Button Offswitch;
    public Button underWaterSwitch;
    public Button FeverSwitch;

    void Start()
    {
        echoFilter = myBlock.GetComponent<AudioEchoFilter>();
        distortionFilter = myBlock.GetComponent<AudioDistortionFilter>();
        reverbFilter = myBlock.GetComponent<AudioReverbFilter>();

        distortionSlider.onValueChanged.AddListener(delegate { UpdateDistortion(); });
        delaySlider.onValueChanged.AddListener(delegate { UpdateDelay(); });

        distortionSlider.value = 0;
        delaySlider.value = 0;

        Offswitch.onClick.AddListener(DisableReverb);
        underWaterSwitch.onClick.AddListener(SetUnderwaterPreset);
        FeverSwitch.onClick.AddListener(SetPsychoticPreset);
    }

    void Update() {
        UpdateUI(Offswitch, AudioReverbPreset.Off);
        UpdateUI(underWaterSwitch, AudioReverbPreset.Underwater);
        UpdateUI(FeverSwitch, AudioReverbPreset.Psychotic);
    }

    void UpdateUI(Button butt, AudioReverbPreset preset) {
        if (reverbFilter.reverbPreset == preset) {
        butt.gameObject.GetComponent<Image>().color = Color.white;
        } else {
        butt.gameObject.GetComponent<Image>().color = Color.black; 
        }
    }

     void UpdateDistortion()
    {
        if (distortionFilter != null)
        {
            distortionFilter.distortionLevel = distortionSlider.value/100;
        }
    }

    void UpdateDelay()
    {
        if (echoFilter != null)
        {
            echoFilter.wetMix = delaySlider.value/100;
        }
    }

    void DisableReverb()
    {
        if (reverbFilter != null)
        {
            reverbFilter.reverbPreset = AudioReverbPreset.Off;
        }
    }

    void SetUnderwaterPreset()
    {
        if (reverbFilter != null)
        {
            reverbFilter.reverbPreset = AudioReverbPreset.Underwater;
        }
    }

    void SetPsychoticPreset()
    {
        if (reverbFilter != null)
        {
            reverbFilter.reverbPreset = AudioReverbPreset.Psychotic;
        }
    }
}
