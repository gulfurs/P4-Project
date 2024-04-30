using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public enum BlockType
    {
        Drums,
        MIDI,
        PartyDrums,
        PartyMIDI
    }

    public List<AudioClip> drumLoops;
    public List<AudioClip> MIDILoops;

    public GameObject drum_Interface;
    public GameObject MIDI_Interface;
    public GameObject partyDrum_Interface;
    public GameObject partyMIDI_Interface;

    public GameObject switchButtons;
}
