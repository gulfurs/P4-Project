using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConsoleReader : MonoBehaviour
{
     public CubeSpawn cubeSpawn;
     public TextMeshProUGUI valueText;
    // Dictionary to store pin numbers and their corresponding values
    private Dictionary<int, float> pinValues = new Dictionary<int, float>();

    void OnEnable()
    {
        Application.logMessageReceived += Log;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= Log;
    }

    public void Log(string logString, string stackTrace, LogType type)
    {
        // Check if the log string starts with "R"
        if (logString.StartsWith("Message arrived: R"))
        {
            // Extract pin number from the log string
            string[] parts = logString.Split(':');
            /*Debug.Log("PARTS LENGTH PARTS LENGTH " + parts.Length);
            Debug.Log("PARTS 1 " + parts[0]);
            Debug.Log("PARTS 2 " + parts[1]);
            Debug.Log("PARTS 3 " + parts[2]); */
            if (parts.Length == 3)
            {  
                    float value;
                    if (float.TryParse(parts[2].Trim(), out value))
                    {
                    UpdateText(value);
                    // Update pinValues dictionary
                    //pinValues[pinNumber] = value;
                        
                    }
            }
        }
    }
    void Update() {
        //UpdateText();
    }
    private void UpdateText(float value) {
        valueText.text = value.ToString("F2");
    }   
    
    // Method to get stored value for a pin
    public float GetStoredValue(int pinNumber)
    {
        float value;
        if (pinValues.TryGetValue(pinNumber, out value))
            return value;
        else
            return -1; // Return -1 if value for pinNumber is not found
    }
}
