using UnityEngine;
using UnityEngine.UI;
using TMPro;

//CLASS FOR SWITCHING IMAGE TO RIGHT/WRONG
public class ImageSwitcher : MonoBehaviour
{
    public Sprite rightImage;
    public Sprite wrongImage;
    public Image targetImage;

    public TextMeshProUGUI PinText;

    void Update()
    {
        // INT VALUE TO BE PARSED
        int textValue;

        if (int.TryParse(PinText.text, out textValue))
        {
            // SHOW WRONGIMAGE IF TEXTVALUE IS DEFAULT VALUE
            if (textValue == 510 || textValue == 0 || textValue == 511)
            {
                //SET IMAGE TO WRONGE IMAGE
                targetImage.sprite = wrongImage;
            }
            else
            {
                //SET IMAGE TO RIGHT IMAGE
                targetImage.sprite = rightImage;
            }
        }
    }
}
