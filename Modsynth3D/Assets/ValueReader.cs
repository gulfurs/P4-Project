using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValueReader : MonoBehaviour
{
    public TextMeshProUGUI Pin1;
    public TextMeshProUGUI Pin2;
    public TextMeshProUGUI Pin3;

    private float pin1Value;
    private float pin2Value;
    private float pin3Value;

    public TextMeshProUGUI value1;
    public TextMeshProUGUI value2;
    public TextMeshProUGUI value3;

    void Start()
    {
       
    }

    void Update() {
        pin1Value = Mathf.RoundToInt(float.Parse(Pin1.text));
        pin2Value = Mathf.RoundToInt(float.Parse(Pin2.text));
        pin3Value = Mathf.RoundToInt(float.Parse(Pin3.text));

        int pin1Integer = GetValue(Mathf.RoundToInt(pin1Value));
        int pin2Integer = GetValue(Mathf.RoundToInt(pin2Value));
        int pin3Integer = GetValue(Mathf.RoundToInt(pin3Value));

        value1.text = pin1Integer.ToString();
        value2.text = pin2Integer.ToString();
        value3.text = pin3Integer.ToString();
    }

    int GetValue(int value)
    {
        if (value >= 490 && value <= 510)
        {
            return 1;
        }
        else if (value >= 590 && value <= 610)
        {
            return 2;
        }
        // Add more conditions here as needed
        else
        {
            return 0; // Or any other default value
        }
    }
}
