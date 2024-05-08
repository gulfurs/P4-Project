using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckIcon : MonoBehaviour
{
    private Image mainIcon;
    private BlockManager blockMan;
    public Image rect1, rect2, rect3;

    void Start()
    {
        blockMan = FindObjectOfType<BlockManager>();
        mainIcon = transform.parent.GetComponent<Image>();
    }

    void Update()
    {
        if (mainIcon != null)
        {
            if (mainIcon.sprite.Equals(blockMan.pianoSprite))
            {
                rect1.color = Color.white;
                rect2.color = Color.black;
                rect3.color = Color.black;
            }
            else if (mainIcon.sprite.Equals(blockMan.trumpetSprite))
            {
                rect1.color = Color.black;
                rect2.color = Color.white;
                rect3.color = Color.black;
            }
            else if (mainIcon.sprite.Equals(blockMan.guitarSprite))
            {
                rect1.color = Color.black;
                rect2.color = Color.black;
                rect3.color = Color.white;
            }
        }
    }
}
