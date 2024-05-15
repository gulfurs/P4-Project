using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImageSwitcher : MonoBehaviour
{
    public Sprite rightImage; // Image to display when the text value is 510
    public Sprite wrongImage; // Image to display when the text value is below 510
    public Image targetImage; // Reference to the Image component to switch

    public TextMeshProUGUI PinText;
    public string stringy;

    void Update()
    {
        stringy = PinText.text;
        // Get the integer value from the text component
        int textValue;
        if (int.TryParse(PinText.text, out textValue))
        {
            // Check if the text value is 510 or below
            if (textValue == 510 || textValue == 0)
            {
                // Set the image to the right image
                targetImage.sprite = wrongImage;
            }
            else
            {
                // Set the image to the wrong image
                targetImage.sprite = rightImage;
            }
        }
    }
}
