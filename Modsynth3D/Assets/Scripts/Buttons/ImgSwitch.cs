using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgSwitch : MonoBehaviour{

    public Image mainImage;
    public Button Option_1;
    public Button Option_2;
    public Button Option_3;

    public Sprite Img_1;
    public Sprite Img_2;
    public Sprite Img_3;
    
    void Start()
    {
        Option_1.onClick.AddListener(() => SetImage(Img_1));
        Option_2.onClick.AddListener(() => SetImage(Img_2));
        Option_3.onClick.AddListener(() => SetImage(Img_3));
    }

   void SetImage(Sprite sprite){
    mainImage.sprite = sprite;
   }
}
