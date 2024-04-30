using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clicker : MonoBehaviour, IClickable
{
    public BlockManager.BlockType blockType;

    [SerializeField]
    private List<AudioClip> blockSounds;

    private GameObject interfaceInstance; 
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
                 
                soundContainer = interfaceInstance.transform.Find("Sounds_Container");

                 for (int i = 0; i < blockSounds.Count - 1; i++)
                {
                    GameObject newButton = Instantiate(changeButton, soundContainer);
                    Button buttonComponent = newButton.GetComponent<Button>();
                    int currentIndex = i;
                    newButton.GetComponentInChildren<TextMeshProUGUI>().text = blockSounds[currentIndex].name;
                    buttonComponent.onClick.AddListener(() => ChangeAudioButton(newButton, currentIndex));
                }
                break;
            case BlockManager.BlockType.MIDI:
                changeButton = blockManager.switchButtons;
                blockSounds.AddRange(blockManager.MIDILoops);
                interfaceInstance = Instantiate(blockManager.MIDI_Interface, interfaceCanvas.transform);
                soundContainer = interfaceInstance.transform.Find("Sounds_Container");

                for (int i = 0; i < blockSounds.Count - 1; i++)
                {
                    GameObject newButton = Instantiate(changeButton, soundContainer);
                    
                    Button buttonComponent = newButton.GetComponent<Button>();
                    int currentIndex = i;
                    newButton.GetComponentInChildren<TextMeshProUGUI>().text = blockSounds[currentIndex].name;
                    buttonComponent.onClick.AddListener(() => ChangeAudioButton(newButton, currentIndex));
                }
                break;
            case BlockManager.BlockType.PartyMIDI:
                changeButton = blockManager.switchButtons;
                blockSounds.AddRange(blockManager.MIDILoops);
                interfaceInstance = Instantiate(blockManager.partyMIDI_Interface, interfaceCanvas.transform);
                soundContainer = interfaceInstance.transform.Find("Sounds_Container");

                 for (int i = 0; i < blockSounds.Count - 1; i++)
                {
                   GameObject newButton = Instantiate(changeButton, soundContainer);
                    Button buttonComponent = newButton.GetComponent<Button>();
                     int currentIndex = i;
                    newButton.GetComponentInChildren<TextMeshProUGUI>().text = blockSounds[currentIndex].name;
                    buttonComponent.onClick.AddListener(() => ChangeAudioButton(newButton, currentIndex));
                }
                break;
             case BlockManager.BlockType.PartyDrums:
                changeButton = blockManager.switchButtons;
                blockSounds.AddRange(blockManager.drumLoops);
                interfaceInstance = Instantiate(blockManager.partyDrum_Interface, interfaceCanvas.transform);
                soundContainer = interfaceInstance.transform.Find("Sounds_Container");

                 for (int i = 0; i < blockSounds.Count - 1; i++)
                {
                   GameObject newButton = Instantiate(changeButton, soundContainer);
                    Button buttonComponent = newButton.GetComponent<Button>();
                     int currentIndex = i;
                    newButton.GetComponentInChildren<TextMeshProUGUI>().text = blockSounds[currentIndex].name;
                    buttonComponent.onClick.AddListener(() => ChangeAudioButton(newButton, currentIndex));
                }
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
        if (blockSounds.Count > 0)
        {
        AudioClip currentClip = blockSounds[0]; // Get first Clip

        // Add current Audioclip in the audio source to the end of the list.
        blockSounds.Add(currentClip);

        // Get the AudioSource
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();

        // Set the AudioClip to the first clip in the list
        audioSource.clip = blockSounds[1];

        audioSource.Play(); //PLAY SOUND

        // Remove the first clip from the list
        blockSounds.RemoveAt(0);

        // Remove duplicates
        for (int i = 0; i < blockSounds.Count - 1; i++)
        {
            // Checks next index, same as this one? Remove. Repeat.
            if (blockSounds[i] == blockSounds[i + 1])
                {
                blockSounds.RemoveAt(i);
                i--;
                }
            }
        }  */ 
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
 