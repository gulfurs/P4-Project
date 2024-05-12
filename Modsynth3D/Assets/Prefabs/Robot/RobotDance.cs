using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotDance : MonoBehaviour
{
    public Animator anim;
    bool Robotisdancing = false;
    public GameObject nodes;
    public GameObject nodes2;
    private bool isBoolParameterSet = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Robotisdancing == false )
        {
            anim.SetBool("IsDancing", isBoolParameterSet);
            isBoolParameterSet = !isBoolParameterSet;
            nodes.SetActive(!isBoolParameterSet);
            nodes2.SetActive(!isBoolParameterSet);
        }
       


    }
}
