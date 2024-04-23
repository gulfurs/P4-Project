using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeThisSingleton : MonoBehaviour
{
    public static MakeThisSingleton instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != this) { Destroy(this); }

        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
