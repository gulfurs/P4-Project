using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CubeSpawn : MonoBehaviour{

    public int integerValue = 0;
    public TextMeshProUGUI texty;

    public GameObject[] cubeCombinations;
    
    public void SpawnCube(){
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
        BoxCollider[] colliders = combination.GetComponentsInChildren<BoxCollider>(true);

        // Enable/disable MeshRenderers
        foreach (MeshRenderer renderer in renderers)
        {
            renderer.enabled = isActive;
        }

        // Enable/disable Colliders
        foreach (BoxCollider collider in colliders)
        {
            collider.enabled = isActive;
        }

        // Set volume of AudioSources
        foreach (AudioSource audioSource in audioSources)
        {
            if (isActive)
            {
                //audioSource.volume = 1f; // Volume 1
            }
            else
            {
                audioSource.volume = 0f; // Volume 0
            }

        }
    }
}
