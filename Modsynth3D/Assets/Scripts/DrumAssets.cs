using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity;

public class DrumAssets : MonoBehaviour
{


    private static DrumAssets _i;

    public static DrumAssets i {
        get
        {
            if (_i == null) _i = Instantiate(Resources.Load<DrumAssets>("DrumAssets"));
            return _i;
        }

    }


    public AudioClip hiHat;


    /*

    public DrumSoundAudioClip[] DrumsoundAudioClipArray;



    [System.Serializable]
    public class DrumSoundAudioClip

    {

        public DrumManager.DrumSound sound;

        public AudioClip audioClip;



    }

    */



}
