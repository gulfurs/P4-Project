using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropDown : MonoBehaviour
{
    // Reference to the Dropdown UI element
    public TMP_Dropdown dropdown;

    // Other scripts that you want to execute based on dropdown selection

    // Add more scripts as needed


    public ChangeReverb reverbChanger;

    void Start()
    {
        // Register a listener for dropdown value changes
        dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropdown);
        });

        reverbChanger = GameObject.Find("ReverbChanger").GetComponent<ChangeReverb>();
    }

    // Method to handle dropdown value changes
    void DropdownValueChanged(TMP_Dropdown dropdown)
    {
        // Get the index of the selected option
        int selectedOptionIndex = dropdown.value;

        // Run different scripts based on the selected option
        switch (selectedOptionIndex)
        {
            case 0:
                // Execute ScriptA
                reverbChanger.SetReverbCave();
                reverbChanger.SetReverbUser();
                Debug.Log("Cave");
                break;
            case 1:
                // Execute ScriptB
                reverbChanger.SetReverbHallway();
                reverbChanger.SetReverbUser();


                Debug.Log("Hallway");

                break;
                // Add more cases for additional options
            case 2:
                reverbChanger.SetReverbForest();
                reverbChanger.SetReverbUser();

                Debug.Log("Forest");
                break;
        }
    }
}
