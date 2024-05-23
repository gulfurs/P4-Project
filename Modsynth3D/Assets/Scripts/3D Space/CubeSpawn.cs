using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//CLASS FOR ACTIVATING/DEACTIVATING BLOCKS BASED ON VALUE
public class CubeSpawn : MonoBehaviour
{
    public int integerValue = 0;
    public TextMeshProUGUI texty;

    public GameObject[] cubeCombinations;

    private AudioMan_buttons audioMan;
    
    void Start()
    {
        //GET AUDIOMAN
        audioMan = FindObjectOfType<AudioMan_buttons>();
    }

    // METHOD FOR "SPAWNING" BLOCKS. 
    public void SpawnCube() 
    {
        // LOOP THROUGH ALL COMBINATIONS
        for (int i = 0; i < cubeCombinations.Length; i++)
        {   
            // GET COMBINATION AT CURRENT INDEX
            GameObject combination = cubeCombinations[i];

            // IF I MATCHES THE INDEX? ACTIVATE BLOCK.
            SetCubeCombinationActive(combination, i == integerValue);
        }
    }

    
    void Update() 
    {
        // CONVERTS/PARSES TEXT TO AN INTEGER VALUE
        int.TryParse(texty.text, out integerValue);

        // UPDATE ACTIVE CUBE EVERY FRAME
        SpawnCube();
    }

    // METHOD TO ACTIVATE/DEACTIVATE BLOCKS
    void SetCubeCombinationActive(GameObject combination, bool isActive)
    {
        // GET RENDERERS, AUDIOSOURCES AND COLLIDERS OF BLOCKS
        MeshRenderer[] renderers = combination.GetComponentsInChildren<MeshRenderer>(true);
        AudioSource[] audioSources = combination.GetComponentsInChildren<AudioSource>(true);
        BoxCollider[] colliders = combination.GetComponentsInChildren<BoxCollider>(true);

        // ENABLE/DISABLE RENDERERS
        foreach (MeshRenderer renderer in renderers)
        {
            renderer.enabled = isActive;
        }

        // ENABLE/DISABLE COLLIDERS
        foreach (BoxCollider collider in colliders)
        {
            collider.enabled = isActive;
        }

        // INCREASE/DECREASE VOLUME
        foreach (AudioSource audioSource in audioSources)
        {
            if (isActive)
            {
                audioSource.volume = audioSource.gameObject.GetComponent<Clicker>().interfaceInstance.GetComponent<EffectHandler>().volSlider.value/100;
            }
            else
            {
                audioSource.volume = 0f;
            }

        }
    }
}
