using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EffectHandler : MonoBehaviour
{
    public GameObject myBlock;
    private BlockManager blockManager;
    private GameObject changeButton;

    private AudioSource blockAudio;
    private Clicker b;

    public Slider volSlider;
    public Slider pitchSlider;

    private AudioEchoFilter echoFilter;
    private AudioDistortionFilter distortionFilter;
    private AudioReverbFilter reverbFilter;

    public Slider distortionSlider;
    public Slider delaySlider;

    public Button Offswitch;
    public Button underWaterSwitch;
    public Button FeverSwitch;
    public Visulizer vis;

    void Start()
    {
        blockManager = FindObjectOfType<BlockManager>();
        changeButton = blockManager.switchButtons;

        blockAudio = myBlock.GetComponent<AudioSource>();
        b = myBlock.GetComponent<Clicker>();
        volSlider.onValueChanged.AddListener(delegate { UpdateVolume(); });
        pitchSlider.onValueChanged.AddListener(delegate { UpdatePitch(); });
        
        if (b.blockType == BlockManager.BlockType.PartyMIDI || b.blockType == BlockManager.BlockType.PartyDrums) 
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
    }

    void Update() 
    {
        if (b.blockType == BlockManager.BlockType.PartyMIDI || b.blockType == BlockManager.BlockType.PartyDrums) 
        {
            UpdateUI(Offswitch, AudioReverbPreset.Off);
            UpdateUI(underWaterSwitch, AudioReverbPreset.Underwater);
            UpdateUI(FeverSwitch, AudioReverbPreset.Psychotic);
        }

        vis.spectrumLaviosa(blockAudio);
    }

    public void ChangeInstrument() 
    {
        Transform sC = null;

        if (b.blockType == BlockManager.BlockType.MIDI)
        {
            if (b.blockSounds[0] == blockManager.MIDILoops[0])
            {
                b.blockSounds.Clear();
                b.blockSounds.AddRange(blockManager.TrumpetLoops);
                sC = transform.Find("Sounds_Container");
                foreach (Transform child in sC)
                {
                    Destroy(child.gameObject);
                }
                SetupButtons(b.blockSounds, changeButton, gameObject, sC);
                ChangeBlockTexture(blockManager.trumpetUV, blockManager.trumpetSprite);
            }
            else if (b.blockSounds[0] == blockManager.TrumpetLoops[0]) 
            {
                b.blockSounds.Clear();
                b.blockSounds.AddRange(blockManager.GuitarLoops);
                sC = transform.Find("Sounds_Container");
                foreach (Transform child in sC)
                {
                    Destroy(child.gameObject);
                }
                SetupButtons(b.blockSounds, changeButton, gameObject, sC);
                ChangeBlockTexture(blockManager.guitarUV, blockManager.guitarSprite);
            } 
            else if (b.blockSounds[0] == blockManager.GuitarLoops[0]) 
            {
                b.blockSounds.Clear();
                b.blockSounds.AddRange(blockManager.MIDILoops);
                sC = transform.Find("Sounds_Container");
                foreach (Transform child in sC)
                {
                    Destroy(child.gameObject);
                }
                SetupButtons(b.blockSounds, changeButton, gameObject, sC);
                ChangeBlockTexture(blockManager.pianoUV, blockManager.pianoSprite);
            }
        } 
        else if (b.blockType == BlockManager.BlockType.PartyMIDI) 
        {
            if (b.blockSounds[0] == blockManager.MIDILoops[0])
            {
                b.blockSounds.Clear();
                b.blockSounds.AddRange(blockManager.TrumpetLoops);
                sC = transform.Find("Sounds_Container");
                foreach (Transform child in sC)
                {
                    Destroy(child.gameObject);
                }
                SetupButtons(b.blockSounds, changeButton, gameObject, sC);
                ChangeBlockTexture(blockManager.partyTrumpetUV, blockManager.trumpetSprite);
            } 
            else if (b.blockSounds[0] == blockManager.TrumpetLoops[0]) 
            {
                b.blockSounds.Clear();
                b.blockSounds.AddRange(blockManager.GuitarLoops);
                sC = transform.Find("Sounds_Container");
                foreach (Transform child in sC)
                {
                    Destroy(child.gameObject);
                }
                SetupButtons(b.blockSounds, changeButton, gameObject, sC);
                ChangeBlockTexture(blockManager.partyGuitarUV, blockManager.guitarSprite);
            } 
            else if (b.blockSounds[0] == blockManager.GuitarLoops[0]) 
            {
                b.blockSounds.Clear();
                b.blockSounds.AddRange(blockManager.MIDILoops);
                sC = transform.Find("Sounds_Container");
                foreach (Transform child in sC)
                {
                    Destroy(child.gameObject);
                }
                SetupButtons(b.blockSounds, changeButton, gameObject, sC);
                ChangeBlockTexture(blockManager.partyPianoUV, blockManager.pianoSprite);
            }
        }
    }

    public void ChangeAudioButton(GameObject button, int index)
    {
    if (blockAudio != null && index < b.blockSounds.Count)
        {
        blockAudio.clip = b.blockSounds[index];
        blockAudio.Play();
        }
    }


    void SetupButtons(List<AudioClip> blockSounds, GameObject changeButton, GameObject interfaceInstance, Transform soundContainer)
    {
        for (int i = 0; i < blockSounds.Count; i++) 
        {
            GameObject newButton = Instantiate(changeButton, soundContainer);
            Button buttonComponent = newButton.GetComponent<Button>();
            int currentIndex = i;
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = blockSounds[currentIndex].name;
            buttonComponent.onClick.AddListener(() => ChangeAudioButton(newButton, currentIndex));
        }

        blockAudio.clip = b.blockSounds[0];
        blockAudio.Play();
    }

    void ChangeBlockTexture(Texture2D texture, Sprite spr)
    {
        Image iconSprite = null;

        Transform iconHolder = transform.Find("InterfaceIcon");
        if (iconHolder != null) 
        {
            iconSprite = iconHolder.GetComponent<Image>();
        }
        MeshRenderer meshRenderer = myBlock.GetComponentInChildren<MeshRenderer>();
        if (meshRenderer != null && meshRenderer.material != null)
        {
            meshRenderer.material.mainTexture = texture;
        }

        if (iconSprite != null)
        {
            iconSprite.sprite = spr;
        }
    }

    void UpdateUI(Button butt, AudioReverbPreset preset) 
    {
        if (reverbFilter.reverbPreset == preset) 
        {
            butt.gameObject.GetComponent<Image>().color = Color.white;
        } 
        else 
        {
            butt.gameObject.GetComponent<Image>().color = Color.black; 
        }
    }

    void UpdateVolume()
    {
        if (blockAudio != null)
        {
            blockAudio.volume = volSlider.value / 100;
        }
    }

    void UpdatePitch()
    {
        if (blockAudio != null)
        {
            blockAudio.pitch = pitchSlider.value;
        }
    }

    void UpdateDistortion()
    {
        if (distortionFilter != null)
        {
            distortionFilter.distortionLevel = distortionSlider.value / 100;
        }
    }

    void UpdateDelay()
    {
        if (echoFilter != null)
        {
            echoFilter.wetMix = delaySlider.value / 100;
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
