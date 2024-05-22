using UnityEngine;
using TMPro;

//CLASS FOR SIMPLIFYING PIN VALUES
public class ValueReader4 : MonoBehaviour
{
    public TextMeshProUGUI Pin1, Pin2, Pin3;
    public TextMeshProUGUI value1, value2, value3;

    private int currentPin1State, currentPin2State, currentPin3State;
    private float lastPin1Value, lastPin2Value, lastPin3Value;
    private float currentStateDuration1 = 0f, currentStateDuration2 = 0f, currentStateDuration3 = 0f;

    private const float stateStableDuration = 2f; // Time before considering the state as stable
    private const float blockChangeDelay = 2f;  // Unused, needed if blocks parameter starts getting unstable

    // Value ranges for different musical blocks
    private readonly int drumRangeLower = 200, drumRangeUpper = 300; // For it to spawn a drum it needs to be within the range 200 - 300
    private readonly int instrumentRangeLower = 400, instrumentRangeUpper = 500; // For it to spawn an instrument it needs to be within the range 400 - 500
    private readonly int partyDrumRangeLower = 100, partyDrumRangeUpper = 200; // For it to spawn a party drum (drum block with an effect block on top), the value should be 100 - 200
    private readonly int partyInstrumentRangeLower = 300, partyInstrumentRangeUpper = 400; // For it to spawn a party instrument (instrument block with an effect block on top), the value should be 300 - 400

    void Update()
    {
        UpdatePinState(ref currentStateDuration1, ref lastPin1Value, ref currentPin1State, Pin1, ref value1, 2);
        UpdatePinState(ref currentStateDuration2, ref lastPin2Value, ref currentPin2State, Pin2, ref value2, 2);
        UpdatePinState(ref currentStateDuration3, ref lastPin3Value, ref currentPin3State, Pin3, ref value3, 2);
    }

    void UpdatePinState(ref float currentStateDuration, ref float lastPinValue, ref int currentPinState, TextMeshProUGUI pinText, ref TextMeshProUGUI valueText, int targetState)
    {
        float pinValue;

        if (float.TryParse(pinText.text, out pinValue))
        {
            // Check if the pin value is within any defined ranges
            if ((pinValue >= drumRangeLower && pinValue <= drumRangeUpper) ||
                (pinValue >= instrumentRangeLower && pinValue <= instrumentRangeUpper) ||
                (pinValue >= partyDrumRangeLower && pinValue <= partyDrumRangeUpper) ||
                (pinValue >= partyInstrumentRangeLower && pinValue <= partyInstrumentRangeUpper))
            {
                currentStateDuration += Time.deltaTime;

                // Display "Pending" if not stabilized and pin value is not 510
                if (currentStateDuration < stateStableDuration && pinValue != 510f)
                {
                    valueText.text = "Pending";
                }
                else
                {
                    // Assign and display the state based on specific value ranges
                    if (pinValue >= drumRangeLower && pinValue <= drumRangeUpper)
                    {
                        currentPinState = targetState; // Drum
                    }
                    else if (pinValue >= instrumentRangeLower && pinValue <= instrumentRangeUpper)
                    {
                        currentPinState = targetState + 1; // Instrument
                    }
                    else if (pinValue >= partyDrumRangeLower && pinValue <= partyDrumRangeUpper)
                    {
                        currentPinState = targetState + 2; // Party Drum
                    }
                    else if (pinValue >= partyInstrumentRangeLower && pinValue <= partyInstrumentRangeUpper)
                    {
                        currentPinState = targetState + 3; // Party Instrument
                    }
                    valueText.text = currentPinState.ToString();
                }
            }
            else
            {
                currentStateDuration = 0f;
                valueText.text = pinValue != 510f ? "Pending" : "0";

                // Reset the state to ensure it registers a change when entering a new range
                if (currentPinState != 0)
                {
                    currentPinState = 0;
                }
            }

            lastPinValue = pinValue;
        }
    }
}
