using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeSpawn : MonoBehaviour{

    public int integerValue = 0;
    public Text texty;

    public GameObject[] cubeCombinations;
    
    public GameObject DrumCube; 
    public GameObject InstrumentCube; 
    public GameObject EffectCube;
  
    public void SpawnCube(){
        /*
        if (integerValue == 1){

            Instantiate(DrumCube, transform.position, Quaternion.identity);
        }

        else if (integerValue == 2){

            Instantiate(InstrumentCube, transform.position, Quaternion.identity);
        }
         else if (integerValue == 3){

            Instantiate(EffectCube, transform.position, Quaternion.identity);
        } */
        /*
        switch(integerValue) {
        case 1:
        DrumCube.SetActive(true);
        InstrumentCube.SetActive(false);
        EffectCube.SetActive(false);
        break;
        case 2:
        DrumCube.SetActive(false);
        InstrumentCube.SetActive(true);
        EffectCube.SetActive(false);
        break;
        case 3:
        DrumCube.SetActive(false);
        InstrumentCube.SetActive(false);
        EffectCube.SetActive(true);
        break;
        default:
        DrumCube.SetActive(false);
        InstrumentCube.SetActive(false);
        EffectCube.SetActive(false);
        break; 
        } */
        // Ensure the value is within the range of the array
        int index = Mathf.Clamp(integerValue - 1, 0, cubeCombinations.Length - 1);

        // Loop through all cube combinations
        for (int i = 0; i < cubeCombinations.Length; i++)
        {
            // Get the cube combination at the current index
            GameObject combination = cubeCombinations[i];

            // Activate the combination if it's the current index, otherwise deactivate it
            bool isActive = i == index;
            SetCubeCombinationActive(combination, isActive);
        }
    }

    void Update() {
        int.TryParse(texty.text, out integerValue);

        SpawnCube();
    }

    // Method to activate/deactivate a cube combination
    void SetCubeCombinationActive(GameObject combination, bool isActive)
    {
        // Get all MeshRenderers and AudioSources
        MeshRenderer[] renderers = combination.GetComponentsInChildren<MeshRenderer>(true);
        AudioSource[] audioSources = combination.GetComponentsInChildren<AudioSource>(true);

        // Enable/disable MeshRenderers
        foreach (MeshRenderer renderer in renderers)
        {
            renderer.enabled = isActive;
        }

        // Set volume of AudioSources
        foreach (AudioSource audioSource in audioSources)
        {
            if (isActive)
                audioSource.volume = 1f; // Volume 1
            else
                audioSource.volume = 0f; // Volume 0
        }
    }
}
