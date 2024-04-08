using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Button_Bang1 : MonoBehaviour
{
    public LibPdInstance pdPatch;

    // Reference to the button UI component
    public Button button;
    public float delay = 1f;
    private Coroutine triggerOffCoroutine;

    void Start()
    {
        // Subscribe to the button click event
        button.onClick.AddListener(OnClick);
    }

    // Function to handle button click
   void OnClick()
    {
        // Send a bang to the PD patch when the button is clicked
        pdPatch.SendBang("triggerOn");

        // Cancel the previous coroutine if it exists
        if (triggerOffCoroutine != null)
        {
            StopCoroutine(triggerOffCoroutine);
        }

        // Start a new coroutine to send triggerOff after the delay
        triggerOffCoroutine = StartCoroutine(SendTriggerOffAfterDelay());
    }

    IEnumerator SendTriggerOffAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Send triggerOff message after the delay
        pdPatch.SendBang("triggerOff");
    }
}
