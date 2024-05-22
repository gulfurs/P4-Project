using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//CLASS FOR SCROLLING BACKGROUND
public class BGScroller : MonoBehaviour
{
    public RawImage backgroundImage;
    [SerializeField] private float x, y;

    void Update(){
        //SCROLLS BACKGROUND AREA BASED ON SCALED VECTOR SPEED
        backgroundImage.uvRect = new Rect(backgroundImage.uvRect.position + new Vector2(x, y) * Time.deltaTime, backgroundImage.uvRect.size);
    }
}
