using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//CLASS TO HANDLE VISUALS, EFFECTS AND SOUNDS WITHIN THE INTERFACE
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
        //GET BLOCKMANAGER
        blockManager = FindObjectOfType<BlockManager>();
        // MAKES SOUNDS CLICKABLE BUTTONS
        changeButton = blockManager.switchButtons;
        //GET BLOCK'S AUDIOSOURCE
        blockAudio = myBlock.GetComponent<AudioSource>();
        //GET BLOCK'S LOGIC
        b = myBlock.GetComponent<Clicker>();

        //UPDATE VOLUME WHEN USING SLIDER
        volSlider.onValueChanged.AddListener(delegate { UpdateVolume(); });
        //UPDATE PITCH WHEN USING SLIDER
        pitchSlider.onValueChanged.AddListener(delegate { UpdatePitch(); });
        
        //GET FILTERS AND OTHER RELEVANT PARTY BLOCK SHENANIGANS
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
        //LIGHT UP CORRECT REVERB PRESET BUTTON
        if (b.blockType == BlockManager.BlockType.PartyMIDI || b.blockType == BlockManager.BlockType.PartyDrums) 
        {
            UpdateUI(Offswitch, AudioReverbPreset.Off);
            UpdateUI(underWaterSwitch, AudioReverbPreset.Underwater);
            UpdateUI(FeverSwitch, AudioReverbPreset.Psychotic);
        }
        //VISUALIZER FOR BLOCK AUDIO
        vis.spectrumLaviosa(blockAudio);
    }

    //CHANGE INSTRUMENT
    public void ChangeInstrument() 
    {
        Transform sC = null;

        //DESTROY ALL CHILDREN BEFORE ADDING NEW CHILDREN
        sC = transform.Find("Sounds_Container");
        foreach (Transform child in sC)
        {
            Destroy(child.gameObject);
        }

        //IF INSTRUMENT BLOCK? ADD LOOPS FROM NEXT INSTRUMENT IN SEQUENCE
        if (b.blockType == BlockManager.BlockType.MIDI)
        {
            if (b.blockSounds[0] == blockManager.MIDILoops[0])
            {
                b.blockSounds.Clear();
                b.blockSounds.AddRange(blockManager.TrumpetLoops);
                SetupButtons(b.blockSounds, changeButton, gameObject, sC);
                ChangeBlockTexture(blockManager.trumpetUV, blockManager.trumpetSprite);
            }
            else if (b.blockSounds[0] == blockManager.TrumpetLoops[0]) 
            {
                b.blockSounds.Clear();
                b.blockSounds.AddRange(blockManager.GuitarLoops);
                SetupButtons(b.blockSounds, changeButton, gameObject, sC);
                ChangeBlockTexture(blockManager.guitarUV, blockManager.guitarSprite);
            } 
            else if (b.blockSounds[0] == blockManager.GuitarLoops[0]) 
            {
                b.blockSounds.Clear();
                b.blockSounds.AddRange(blockManager.MIDILoops);
                SetupButtons(b.blockSounds, changeButton, gameObject, sC);
                ChangeBlockTexture(blockManager.pianoUV, blockManager.pianoSprite);
            }
        } 
        //IF PARTY INSTRUMENT BLOCK? ADD LOOPS FROM NEXT INSTRUMENT IN SEQUENCE
        else if (b.blockType == BlockManager.BlockType.PartyMIDI) 
        {
            if (b.blockSounds[0] == blockManager.MIDILoops[0])
            {
                b.blockSounds.Clear();
                b.blockSounds.AddRange(blockManager.TrumpetLoops);
                SetupButtons(b.blockSounds, changeButton, gameObject, sC);
                ChangeBlockTexture(blockManager.partyTrumpetUV, blockManager.trumpetSprite);
            } 
            else if (b.blockSounds[0] == blockManager.TrumpetLoops[0]) 
            {
                b.blockSounds.Clear();
                b.blockSounds.AddRange(blockManager.GuitarLoops);
                SetupButtons(b.blockSounds, changeButton, gameObject, sC);
                ChangeBlockTexture(blockManager.partyGuitarUV, blockManager.guitarSprite);
            } 
            else if (b.blockSounds[0] == blockManager.GuitarLoops[0]) 
            {
                b.blockSounds.Clear();
                b.blockSounds.AddRange(blockManager.MIDILoops);
                SetupButtons(b.blockSounds, changeButton, gameObject, sC);
                ChangeBlockTexture(blockManager.partyPianoUV, blockManager.pianoSprite);
            }
        }
    }
    //METHOD/LISTENER FOR SOUND BUTTONS
    public void ChangeAudioButton(GameObject button, int index)
    {
        if (blockAudio != null && index < b.blockSounds.Count)
        {
            blockAudio.clip = b.blockSounds[index];
            blockAudio.Play();
        }
    }
    //METHOD FOR INSTANTIATING SOUND BUTTONS
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
    //METHOD FOR CHANGING TEXTURE AND SPRITE IN CASE OF 'CHANGE OF INSTRUMENT
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
    //UPDATE REVERB INDICATOR
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
    //UPDATES VOLUME WITH SLIDER
    void UpdateVolume()
    {
        if (blockAudio != null)
        {
            blockAudio.volume = volSlider.value / 100;
        }
    }
    //UPDATES PITCH WITH SLIDER
    void UpdatePitch()
    {
        if (blockAudio != null)
        {
            blockAudio.pitch = pitchSlider.value;
        }
    }
    //UPDATES DISTORTION WITH SLIDER
    void UpdateDistortion()
    {
        if (distortionFilter != null)
        {
            distortionFilter.distortionLevel = distortionSlider.value / 100;
        }
    }
    //UPDATES ECHO WITH SLIDER
    void UpdateDelay()
    {
        if (echoFilter != null)
        {
            echoFilter.wetMix = delaySlider.value / 100;
        }
    }
    //TURNS REVERB OFF
    void DisableReverb()
    {
        if (reverbFilter != null)
        {
            reverbFilter.reverbPreset = AudioReverbPreset.Off;
        }
    }
    //TURNS REVERB ON UNDERWATER PRESET
    void SetUnderwaterPreset()
    {
        if (reverbFilter != null)
        {
            reverbFilter.reverbPreset = AudioReverbPreset.Underwater;
        }
    }
    //TURNS REVERB ON PSYCOTIC PRESET
    void SetPsychoticPreset()
    {
        if (reverbFilter != null)
        {
            reverbFilter.reverbPreset = AudioReverbPreset.Psychotic;
        }
    }
}
