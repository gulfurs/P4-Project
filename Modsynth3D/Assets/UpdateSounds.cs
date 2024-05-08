using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateSounds : MonoBehaviour
{
    public GameObject thyBlock;

    void Update()
    {
       UpdateSoundButtons(); 
    }

    void UpdateSoundButtons()
    {
        // Get the audio source component of thyBlock
        AudioSource audioSource = thyBlock.GetComponent<AudioSource>();

        // Loop through each child object of the transform
        foreach (Transform child in transform)
        {
            TextMeshProUGUI textMeshPro = child.GetComponentInChildren<TextMeshProUGUI>();
            if (textMeshPro == null)
            {
                continue;
            }

            if (textMeshPro.text == audioSource.clip.name)
            {
                textMeshPro.color = Color.white;
            }
            else
            {
                textMeshPro.color = Color.black;
            }
        }
    }
}
