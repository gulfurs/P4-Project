using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public enum BlockType
    {
        Drums,
        Instrument,
        Piano
    }

    public List<AudioClip> drumLoops;
    public List<AudioClip> InstrumentsLoops;
    public List<AudioClip> pianoLoops;

    public GameObject drumInterface;
    public GameObject instrumentInterface;
    public GameObject pianoInterface;

    public GameObject drumButton;
}
