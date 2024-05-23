using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//CLASS TO ACT ACCORDINGLY WHEN CORRECT INSTRUMENT SPRITE
public class CheckIcon : MonoBehaviour
{
    private Image mainIcon;
    private BlockManager blockMan;
    public Image rect1, rect2, rect3;

    void Start()
    {
        //GET BLOCKMANAGER
        blockMan = FindObjectOfType<BlockManager>();
        //GET ICON IMAGE
        mainIcon = transform.parent.GetComponent<Image>();
    }

    //LIGHT UP CORRECT RECTANGLE WHEN CORRECT SPRITE
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
