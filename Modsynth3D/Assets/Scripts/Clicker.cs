using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour, IClickable
{
    public BlockManager.BlockType blockType;

    [SerializeField]
    private List<AudioClip> blockSounds;

    private GameObject interfaceInstance; 

    //private ChangeAudio changeAudio;

    void Start () {
        BlockManager blockManager = FindObjectOfType<BlockManager>();
        GameObject interfaceCanvas = GameObject.Find("InterfaceCanvas");

        blockSounds.Clear();

        /*AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null && audioSource.clip != null)
        {
        blockSounds.Insert(0, audioSource.clip);
        }*/

        // GameObject changeAudioObject = GameObject.Find("Snare");

        //  if (changeAudioObject != null)
        // {
        //     changeAudio = changeAudioObject.GetComponent<ChangeAudio>();
        //     blockSounds.Add(changeAudio.audioClip);
        // }


    if (interfaceCanvas != null) {
       switch (blockType)
        {
            case BlockManager.BlockType.Drums:
                blockSounds.AddRange(blockManager.drumLoops);
                interfaceInstance = Instantiate(blockManager.drumInterface, interfaceCanvas.transform);
                break;
            case BlockManager.BlockType.Instrument:
                blockSounds.AddRange(blockManager.InstrumentsLoops);
                interfaceInstance = Instantiate(blockManager.instrumentInterface, interfaceCanvas.transform);
                break;
            case BlockManager.BlockType.Piano:
                blockSounds.AddRange(blockManager.pianoLoops);
                interfaceInstance = Instantiate(blockManager.pianoInterface, interfaceCanvas.transform);
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
    {
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
 