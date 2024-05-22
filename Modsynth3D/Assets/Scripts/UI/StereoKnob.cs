using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// CLASS TO SHOW SLIDER VALUE
public class StereoKnob : MonoBehaviour
{
    private TextMeshProUGUI knobValue;
    private Slider slider;
    public bool isInt = true;

    void Start()
    {
        // GET TEXT UNDER SLIDER
        knobValue = GetComponentInChildren<TextMeshProUGUI>(true);
        // GET SLIDER
        slider = GetComponent<Slider>();
        // UPDATE WHEN SLIDER VALUE CHANGES
        slider.onValueChanged.AddListener(delegate { UpdateText(); });

        UpdateText();
    }

    // METHOD TO UPDATE TEXT TO VALUE TO PERCENTAGE FORMAT
    void UpdateText()
    {
        if (isInt)
        {
            int roundValue = Mathf.RoundToInt(slider.value);
            knobValue.text = roundValue.ToString();
        } else
        {
            float floatValue = slider.value * 100;
            knobValue.text = floatValue.ToString("F0");
        }
    }
}
