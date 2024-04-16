using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Good old scene changer script
public class ChangeScene : MonoBehaviour
{
    public void LoadAScene(int sceneNum){
        SceneManager.LoadScene(sceneNum); //This changes the scene depending on the scene number
    }
}

