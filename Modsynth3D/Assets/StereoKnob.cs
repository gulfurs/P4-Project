using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StereoKnob : MonoBehaviour
{
    private TextMeshProUGUI knobValue;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        knobValue = GetComponentInChildren<TextMeshProUGUI>();
        slider = GetComponent<Slider>();

        slider.onValueChanged.AddListener(delegate { UpdateText(); });

        UpdateText();
    }

    void UpdateText()
    {
        int roundValue = Mathf.RoundToInt(slider.value);

        knobValue.text = roundValue.ToString();
    }
}
