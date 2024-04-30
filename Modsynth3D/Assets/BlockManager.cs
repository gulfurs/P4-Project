using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockManager : MonoBehaviour
{
    public enum BlockType
    {
        Drums,
        MIDI,
        PartyDrums,
        PartyMIDI
    }

    public Sprite pianoSprite;
    public Sprite trumpetSprite;
    public Sprite guitarSprite;

    public Texture2D pianoUV;
    public Texture2D trumpetUV;
    public Texture2D guitarUV;
    public Texture2D partyPianoUV;
    public Texture2D partyTrumpetUV;
    public Texture2D partyGuitarUV;

    public List<AudioClip> drumLoops;
    public List<AudioClip> MIDILoops;
    public List<AudioClip> TrumpetLoops;
    public List<AudioClip> GuitarLoops;

    public GameObject drum_Interface;
    public GameObject MIDI_Interface;
    public GameObject partyDrum_Interface;
    public GameObject partyMIDI_Interface;

    public GameObject switchButtons;
}
