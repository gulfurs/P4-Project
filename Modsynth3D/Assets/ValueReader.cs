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
        // Null check for Pin1, Pin2, and Pin3
        if (Pin1 != null && Pin2 != null && Pin3 != null)
        {
            float pin1Value, pin2Value, pin3Value;

            // Try parsing the text from Pin1, Pin2, and Pin3
            if (float.TryParse(Pin1.text, out pin1Value) &&
                float.TryParse(Pin2.text, out pin2Value) &&
                float.TryParse(Pin3.text, out pin3Value))
            {
                int pin1Integer = GetValue(Mathf.RoundToInt(pin1Value));
                int pin2Integer = GetValue(Mathf.RoundToInt(pin2Value));
                int pin3Integer = GetValue(Mathf.RoundToInt(pin3Value));

                value1.text = pin1Integer.ToString();
                value2.text = pin2Integer.ToString();
                value3.text = pin3Integer.ToString();
            }
        }
    }

    int GetValue(int value)
    {
        if (value >= 490 && value <= 510)
        {
            return 2;
        }
        else if (value >= 239 && value <= 260)
        {
            return 3;
        }
        else if (value >= 355 && value <= 410)
        {
            return 4;
        }
        else if (value >= 205 && value <= 225)
        {
            return 5;
        }
        else
        {
            return 0; // Or any other default value
        }
    }
}
