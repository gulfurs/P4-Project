using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//CLASS FOR READING CONSOLE FOR EACH PIN
public class ConsoleReader : MonoBehaviour
{
    public TextMeshProUGUI valueText;
    public TextMeshProUGUI valueText2;
    public TextMeshProUGUI valueText3;

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
        // Check if the log string starts with "Message arrived: R1"
        if (logString.StartsWith("Message arrived: R1"))
        {
            // Split the log string
            string[] parts = logString.Split(':');
           
            if (parts.Length == 3)
            {  
                float value;
                if (float.TryParse(parts[2].Trim(), out value))
                {
                    UpdateText(valueText, value);
                }
            }
        }
        // Check if the log string starts with "Message arrived: R2"
        else if (logString.StartsWith("Message arrived: R2"))
        {
            // Split the log string
            string[] parts = logString.Split(':');
           
            if (parts.Length == 3)
            {  
                float value;
                if (float.TryParse(parts[2].Trim(), out value))
                {
                    UpdateText(valueText2, value);
                }
            }
        }
        // Check if the log string starts with "Message arrived: R3"
        else if (logString.StartsWith("Message arrived: R3"))
        {
            // Split the log string
            string[] parts = logString.Split(':');
           
            if (parts.Length == 3)
            {  
                float value;
                if (float.TryParse(parts[2].Trim(), out value))
                {
                    UpdateText(valueText3, value);
                }
            }
        }
    }

    private void UpdateText(TextMeshProUGUI textMesh, float value) {
        textMesh.text = value.ToString();
    }   
}
