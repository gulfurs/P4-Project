using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawn : MonoBehaviour{

    
    public GameObject DrumCube; 
    public GameObject InstrumentCube; 
    public GameObject EffectCube;
  
    public void SpawnCube(int value){
        
        if (value == 1){

            Instantiate(DrumCube, transform.position, Quaternion.identity);
        }

        else if (value == 2){

            Instantiate(InstrumentCube, transform.position, Quaternion.identity);
        }
         else if (value == 3){

            Instantiate(EffectCube, transform.position, Quaternion.identity);
        }
        
    }

}
