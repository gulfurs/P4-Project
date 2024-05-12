using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceManager : MonoBehaviour
{
    public CubeSpawn cs1, cs2, cs3;

    public GameObject robotidle;
    public GameObject robotsmalldance;
    public GameObject robotBreakDance;


    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        int totalvalue;
        totalvalue = cs1.integerValue + cs2.integerValue + cs3.integerValue;
        if (totalvalue >= 1 && totalvalue <= 2)
        {
            robotsmalldance.SetActive(true);
            robotidle.SetActive(false);
            robotBreakDance.SetActive(false);
        }
        else if (totalvalue >= 3)
        {
            robotBreakDance.SetActive(true);
            robotidle.SetActive(false);
            robotsmalldance.SetActive(false);
        }
        else
        {
            robotidle.SetActive(true);
            robotBreakDance.SetActive(false);
            robotsmalldance.SetActive(false);

        }
        
    }
}
