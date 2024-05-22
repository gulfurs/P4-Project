using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

//CLASS TO MANAGE DANCE OF ROBOT
public class DanceManager : MonoBehaviour
{
    public Sprite checkMark;
    public List<Image> checkList;
    public GameObject robotIdle;
    public GameObject robotDance;
    public GameObject robotBreak;
    public GameObject nodes1;
    public GameObject nodes2;

    void Start()
    {
        // GET LIST
        checkList = new List<Image>();
    }

    void Update()
    {
        checkList.Clear();
        checkForcheck();

        // DANCE VARIES BY NUMBER OF CHECKMARKS
        if (checkList.Count == 1) {
            robotIdle.SetActive(false);
            robotDance.SetActive(true);
            robotBreak.SetActive(false);
            nodes1.SetActive(true);
            nodes2.SetActive(true);
        } else if (checkList.Count >= 2) {
            robotIdle.SetActive(false);
            robotDance.SetActive(false);
            robotBreak.SetActive(true);
            nodes1.SetActive(true);
            nodes2.SetActive(true);
        } else {
            robotIdle.SetActive(true);
            robotDance.SetActive(false);
            robotBreak.SetActive(false);
            nodes1.SetActive(false);
            nodes2.SetActive(false);
        }
    }

    void checkForcheck()
    {
        // FIND ALL IMAGES
        Image[] allImages = FindObjectsOfType<Image>(true);

        // ADD EACH CHECKMARK TO THE CHECKLIST
        foreach (Image img in allImages)
        {
            if (img.sprite == checkMark)
            {
                checkList.Add(img);
            }
        }
    }
}
