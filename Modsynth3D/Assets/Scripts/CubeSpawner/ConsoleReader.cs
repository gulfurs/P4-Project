using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleReader : MonoBehaviour
{
     public CubeSpawn cubeSpawn;
     public Text texty;
    public int storedValue = 1; 

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
        string valueString = logString.Substring("Value produced: ".Length);
        int value;
        if (int.TryParse(valueString, out value))
        {
            storedValue = value;
            /*if(storedValue == 1){
                cubeSpawn.SpawnCube(1);
            }*/
            Debug.Log(storedValue);
        }
    }
    public int GetStoredValue()
    {
        return storedValue;
    }

    void Update() {
        int.TryParse(texty.text, out storedValue);
    }
}
