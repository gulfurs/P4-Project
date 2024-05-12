using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StereoKnob : MonoBehaviour
{
    private TextMeshProUGUI knobValue;
    private Slider slider;
    public bool isInt = true;

    // Start is called before the first frame update
    void Start()
    {
        knobValue = GetComponentInChildren<TextMeshProUGUI>(true);
        slider = GetComponent<Slider>();

        slider.onValueChanged.AddListener(delegate { UpdateText(); });

        UpdateText();

    }

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
