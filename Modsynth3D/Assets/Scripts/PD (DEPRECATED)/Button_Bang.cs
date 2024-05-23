using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Bang : MonoBehaviour
{

    /// The PD patch we're going to communicate with.
    public LibPdInstance pdPatch;

    /// We send a bang when the player steps on the button (enters the collision
    /// volume).
    void OnTriggerEnter(Collider other)
    {
        //To send a bang to our PD patch, the patch needs a named receive object
        //(in this case, named triggerOn), and then we can just use the
        //SendBang() function to send a bang to that object from Unity.

        pdPatch.SendBang("triggerOn");
    }

    /// We send a different bang when the player steps off the button (leaves
    /// the collision volume).
    void OnTriggerExit(Collider other)
    {
        pdPatch.SendBang("triggerOff");
    }
}
