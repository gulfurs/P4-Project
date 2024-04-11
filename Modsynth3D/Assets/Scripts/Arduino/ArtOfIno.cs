using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class ArtOfIno: MonoBehaviour
{
    SerialPort serialPort;
    public string portName = "COM5";
    public int baudRate = 9600;

    void Start()
    {
        serialPort = new SerialPort(portName, baudRate);

        try
        {
            serialPort.Open();
            Debug.Log("Arduino connected on " + portName);
        }
        catch (System.Exception)
        {
            Debug.LogError("Failed to connect to Arduino on " + portName);
        }
    }

    void OnApplicationQuit()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
            Debug.Log("Serial port closed.");
        }
    }
}
