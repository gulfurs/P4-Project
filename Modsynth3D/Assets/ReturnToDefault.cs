using UnityEngine;
using UnityEngine.UI;

public class ReturnToDefault : MonoBehaviour
{
    Transform sliderParent;

    public float defaultValue;

    void Start()
    {
        sliderParent = transform.parent; 
    }

    public void ResetSlider()
    {
        sliderParent.GetComponent<Slider>().value = defaultValue;
    }
}
