using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clicker : MonoBehaviour, IClickable
{
    public BlockManager.BlockType blockType;

    [SerializeField]
    public List<AudioClip> blockSounds;

    public GameObject interfaceInstance; 
    private GameObject changeButton;
    //private ChangeAudio changeAudio;

    void Start () {
        BlockManager blockManager = FindObjectOfType<BlockManager>();
        GameObject interfaceCanvas = GameObject.Find("InterfaceCanvas");

        blockSounds.Clear();

    if (interfaceCanvas != null) {

         Transform soundContainer = null;
         AudioSource audioSource = gameObject.GetComponent<AudioSource>(); 

       switch (blockType)
        {
            case BlockManager.BlockType.Drums:
                changeButton = blockManager.switchButtons;
                blockSounds.AddRange(blockManager.drumLoops);
                interfaceInstance = Instantiate(blockManager.drum_Interface, interfaceCanvas.transform);
                interfaceInstance.GetComponent<EffectHandler>().myBlock = gameObject;
                soundContainer = interfaceInstance.transform.Find("Sounds_Container");
                soundContainer.GetComponent<UpdateSounds>().thyBlock = gameObject;
                SetupButtons(blockSounds, changeButton, interfaceInstance, soundContainer);

                break;
            case BlockManager.BlockType.MIDI:
                changeButton = blockManager.switchButtons;
                blockSounds.AddRange(blockManager.MIDILoops);
                interfaceInstance = Instantiate(blockManager.MIDI_Interface, interfaceCanvas.transform);
                interfaceInstance.GetComponent<EffectHandler>().myBlock = gameObject;
                soundContainer = interfaceInstance.transform.Find("Sounds_Container");
                soundContainer.GetComponent<UpdateSounds>().thyBlock = gameObject;
                SetupButtons(blockSounds, changeButton, interfaceInstance, soundContainer);

                break;
            case BlockManager.BlockType.PartyMIDI:
                changeButton = blockManager.switchButtons;
                blockSounds.AddRange(blockManager.MIDILoops);
                interfaceInstance = Instantiate(blockManager.partyMIDI_Interface, interfaceCanvas.transform);
                interfaceInstance.GetComponent<EffectHandler>().myBlock = gameObject;
                soundContainer = interfaceInstance.transform.Find("Sounds_Container");
                soundContainer.GetComponent<UpdateSounds>().thyBlock = gameObject;
                SetupButtons(blockSounds, changeButton, interfaceInstance, soundContainer);

                break;
             case BlockManager.BlockType.PartyDrums:
                changeButton = blockManager.switchButtons;
                blockSounds.AddRange(blockManager.drumLoops);
                interfaceInstance = Instantiate(blockManager.partyDrum_Interface, interfaceCanvas.transform);
                interfaceInstance.GetComponent<EffectHandler>().myBlock = gameObject;
                soundContainer = interfaceInstance.transform.Find("Sounds_Container");
                soundContainer.GetComponent<UpdateSounds>().thyBlock = gameObject;
                SetupButtons(blockSounds, changeButton, interfaceInstance, soundContainer);

                break;
            default:
                break;
            } 
        } 
    }

    public void Update() {
    }

    public void OnLeftClick()
    {
        if (interfaceInstance != null)
        {
            interfaceInstance.SetActive(true); 
        }
    }

    public void OnRightClick()
{/*
    BlockManager blockManager = FindObjectOfType<BlockManager>();
    Transform sC;

        if (blockType == BlockManager.BlockType.MIDI)
        {
            if (blockSounds[0] == blockManager.MIDILoops[0])
            {

                blockSounds.Clear();
                blockSounds.AddRange(blockManager.TrumpetLoops);
                sC = interfaceInstance.transform.Find("Sounds_Container");
                foreach (Transform child in sC)
                {
                Destroy(child.gameObject);
                }
                SetupButtons(blockSounds, changeButton, interfaceInstance, sC);
                ChangeBlockTexture(blockManager.trumpetUV, blockManager.trumpetSprite);
            } else if (blockSounds[0] == blockManager.TrumpetLoops[0]) {
                blockSounds.Clear();
                blockSounds.AddRange(blockManager.GuitarLoops);
                sC = interfaceInstance.transform.Find("Sounds_Container");
                foreach (Transform child in sC)
                {
                Destroy(child.gameObject);
                }
                SetupButtons(blockSounds, changeButton, interfaceInstance, sC);
                ChangeBlockTexture(blockManager.guitarUV, blockManager.guitarSprite);
            } else if (blockSounds[0] == blockManager.GuitarLoops[0]) {
                blockSounds.Clear();
                blockSounds.AddRange(blockManager.MIDILoops);
                sC = interfaceInstance.transform.Find("Sounds_Container");
                foreach (Transform child in sC)
                {
                Destroy(child.gameObject);
                }
                SetupButtons(blockSounds, changeButton, interfaceInstance, sC);
                ChangeBlockTexture(blockManager.pianoUV, blockManager.pianoSprite);
        }
    } if (blockType == BlockManager.BlockType.PartyMIDI) {
        if (blockSounds[0] == blockManager.MIDILoops[0])
        {
            blockSounds.Clear();
            blockSounds.AddRange(blockManager.TrumpetLoops);
            sC = interfaceInstance.transform.Find("Sounds_Container");
            foreach (Transform child in sC)
            {
            Destroy(child.gameObject);
            }
            SetupButtons(blockSounds, changeButton, interfaceInstance, sC);
            ChangeBlockTexture(blockManager.partyTrumpetUV, blockManager.trumpetSprite);
        } else if (blockSounds[0] == blockManager.TrumpetLoops[0]) {
            blockSounds.Clear();
            blockSounds.AddRange(blockManager.GuitarLoops);
            sC = interfaceInstance.transform.Find("Sounds_Container");
            foreach (Transform child in sC)
            {
            Destroy(child.gameObject);
            }
            SetupButtons(blockSounds, changeButton, interfaceInstance, sC);
            ChangeBlockTexture(blockManager.partyGuitarUV, blockManager.guitarSprite);
        } else if (blockSounds[0] == blockManager.GuitarLoops[0]) {
            blockSounds.Clear();
            blockSounds.AddRange(blockManager.MIDILoops);
            sC = interfaceInstance.transform.Find("Sounds_Container");
            foreach (Transform child in sC)
            {
            Destroy(child.gameObject);
            }
            SetupButtons(blockSounds, changeButton, interfaceInstance, sC);
            ChangeBlockTexture(blockManager.partyPianoUV, blockManager.pianoSprite);
        }
    }*/
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
}

    public void ChangeAudioButton(GameObject button, int index)
    {
    AudioSource audioSource = GetComponent<AudioSource>();

    if (audioSource != null && index < blockSounds.Count)
        {
        audioSource.clip = blockSounds[index];
        audioSource.Play();
        }
    }

    void ChangeBlockTexture(Texture2D texture, Sprite spr)
    {
    Image iconSprite = null;

    Transform iconHolder = interfaceInstance.transform.Find("InterfaceIcon");
    if (iconHolder != null) {
    iconSprite = iconHolder.GetComponent<Image>();

    }
    MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();
    if (meshRenderer != null && meshRenderer.material != null)
        {
        meshRenderer.material.mainTexture = texture;
        }

    if (iconSprite != null)
        {
        iconSprite.sprite = spr;
        }
    }
}


//     public void SetDrumHiHat()
//     {

//         AudioSource audioSource = gameObject.GetComponent<AudioSource>();
//         audioSource.clip = blockSounds[0];
//         audioSource.Play();

//     }


// public void SetDrumSnare()
//     {

//         AudioSource audioSource = gameObject.GetComponent<AudioSource>();
//         audioSource.clip = blockSounds[1];
//         audioSource.Play();

//     }


// public void SetDrumBass()
//     {

//         AudioSource audioSource = gameObject.GetComponent<AudioSource>();
//         audioSource.clip = blockSounds[2];
//         audioSource.Play();

//     }
 