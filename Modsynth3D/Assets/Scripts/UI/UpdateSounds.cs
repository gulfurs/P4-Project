using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// CLASS TO UPDATE SOUND BUTTONS TO INDICATE CURRENT RUNNING SOUND
public class UpdateSounds : MonoBehaviour
{
    public GameObject thyBlock;

    void Update()
    {
       UpdateSoundButtons(); 
    }

    // METHOD FOR MAKING RUNNING SOUND CLIP TEXT WHITE
    void UpdateSoundButtons()
    {
        // GET AUDIO SOURCE FROM BLOCK
        AudioSource audioSource = thyBlock.GetComponent<AudioSource>();

        // CHECKS CHILD
        foreach (Transform child in transform)
        {
            //GET TEXTMESH(UI) FOR EACH CHILD
            TextMeshProUGUI textMeshPro = child.GetComponentInChildren<TextMeshProUGUI>();

            // VALIDATE IF THERE IS A TEXTMESH
            if (textMeshPro == null)
            {
                continue;
            }

            // IF TEXT EQUAL NAME OF CURRENT BLOCK SOUND CLIP NAME ACT ACCORDINGLY
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
