using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//CLASS ASSIGNING ATTRIBUTES TO EACH INDIVIDUAL BLOCK
public class Clicker : MonoBehaviour, IClickable
{
    public BlockManager.BlockType blockType;

    [SerializeField]
    public List<AudioClip> blockSounds;

    public GameObject interfaceInstance; 
    private GameObject changeButton;
    private AudioSource audioSource;

    void Start () {
        //GET BLOCKMANAGER : HOME TO BLOCK ATTRIBUTES
        BlockManager blockManager = FindObjectOfType<BlockManager>();

        //PARENT OBJECT TO THE INTERFACES
        GameObject interfaceCanvas = GameObject.Find("InterfaceCanvas");

        blockSounds.Clear();

    if (interfaceCanvas != null) {
        
        //PARENT TRANSFORM TO THE BLOCKS
         Transform soundContainer = null;

        //GETS AUDIOSOUCE
        audioSource = gameObject.GetComponent<AudioSource>(); 

        //ADDS CORRECT RANGE OF SOUNDS TO THE LIST OF SOUNDS 
        //INSTANTIATES CORRECT BUTTONS BASED ON TYPE OF BLOCK
        //ASSIGNS THIS BLOCK AS TO THE INTERFACE PROPERTIES
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

    //METHOD FOR RIGHT CLICK ON BLOCK : ENABLE INTEFACE
    public void OnLeftClick()
    {
        if (interfaceInstance != null)
        {
            interfaceInstance.SetActive(true); 
        }
    }

    //METHOD FOR RIGHT CLICK ON BLOCK
    public void OnRightClick()
    {
    }
    
    //METHOD FOR INSTANTIATING BUTTONS
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

    //METHOD(LISTENER) FOR CHANGE OF SOUND
    public void ChangeAudioButton(GameObject button, int index)
    {
    if (audioSource != null && index < blockSounds.Count)
        {
        audioSource.clip = blockSounds[index];
        audioSource.Play();
        }
    }
}
