using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//CLASS FOR BLOCK ATTRIBUTES
public class BlockManager : MonoBehaviour
{
    //TYPES OF BLOCKS
    public enum BlockType
    {
        Drums,
        MIDI,
        PartyDrums,
        PartyMIDI
    }

    //SPRITES FOR BLOCKS(INSTRUMENT ONLY)
    public Sprite pianoSprite;
    public Sprite trumpetSprite;
    public Sprite guitarSprite;

    //TEXTURE FOR BLOCKS(INSTRUMENT ONLY)
    public Texture2D pianoUV;
    public Texture2D trumpetUV;
    public Texture2D guitarUV;
    public Texture2D partyPianoUV;
    public Texture2D partyTrumpetUV;
    public Texture2D partyGuitarUV;

    //LIST OF SOUNDS
    public List<AudioClip> drumLoops;
    public List<AudioClip> MIDILoops;
    public List<AudioClip> TrumpetLoops;
    public List<AudioClip> GuitarLoops;

    //INTERFACE FOR BLOCKS
    public GameObject drum_Interface;
    public GameObject MIDI_Interface;
    public GameObject partyDrum_Interface;
    public GameObject partyMIDI_Interface;

    //SOUND BUTTON TEMPLATE
    public GameObject switchButtons;
}
