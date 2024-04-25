using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DrumManager
{
  
    public enum DrumSound
    {
        Clap1,
        Clap2,
        Hihat,
        Snare,
    }



    public static void PlaySound()
    {
        GameObject soundDrumGameObject = new GameObject("SoundDrum");
        AudioSource audioSource = soundDrumGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(DrumAssets.i.hiHat);
    }


    /*
    private static AudioClip GetAudioClip(DrumSound sound)
    {
        foreach (DrumAssets.DrumSoundAudioClip drumSoundAudioClip in DrumAssets.i.DrumsoundAudioClipArray)
        {
            if (drumSoundAudioClip.sound == sound)
            {
                return drumSoundAudioClip.audioClip;
            }
        }
        Debug.Log("Error");
        return null;
    }
    */


}
