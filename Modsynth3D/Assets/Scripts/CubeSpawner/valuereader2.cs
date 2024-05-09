using UnityEngine;
using TMPro;

public class ValueReader4 : MonoBehaviour
{
    public TextMeshProUGUI Pin1;
    public TextMeshProUGUI Pin2;
    public TextMeshProUGUI Pin3;

    public TextMeshProUGUI value1;
    public TextMeshProUGUI value2;
    public TextMeshProUGUI value3;

    private int currentPin1State;
    private int currentPin2State;
    private int currentPin3State;

    private float lastPin1Value;
    private float lastPin2Value;
    private float lastPin3Value;

    private float currentStateDuration1 = 0f;
    private float currentStateDuration2 = 0f;
    private float currentStateDuration3 = 0f;

    private const float stateStableDuration = 2f; // Time in seconds to consider the state stable
    private const float blockChangeDelay = 2f; // Delay in seconds before allowing block change

    void Update()
    {
        UpdatePinState(ref currentStateDuration1, ref lastPin1Value, ref currentPin1State, Pin1, ref value1, 200, 300, 400, 500, 100, 200, 300, 400, 2);
        UpdatePinState(ref currentStateDuration2, ref lastPin2Value, ref currentPin2State, Pin2, ref value2, 200, 300, 400, 500, 100, 200, 300, 400, 2);
        UpdatePinState(ref currentStateDuration3, ref lastPin3Value, ref currentPin3State, Pin3, ref value3, 200, 300, 400, 500, 100, 200, 300, 400, 2);
    }

    void UpdatePinState(ref float currentStateDuration, ref float lastPinValue, ref int currentPinState, TextMeshProUGUI pinText, ref TextMeshProUGUI valueText,
                        int drumRangeLower, int drumRangeUpper, int pianoRangeLower, int pianoRangeUpper, int partyDrumRangeLower, int partyDrumRangeUpper,
                        int partyPianoRangeLower, int partyPianoRangeUpper, int targetState)
    {
        float pinValue;

        if (float.TryParse(pinText.text, out pinValue))
        {
            if ((pinValue >= drumRangeLower && pinValue <= drumRangeUpper) ||
                (pinValue >= pianoRangeLower && pinValue <= pianoRangeUpper) ||
                (pinValue >= partyDrumRangeLower && pinValue <= partyDrumRangeUpper) ||
                (pinValue >= partyPianoRangeLower && pinValue <= partyPianoRangeUpper))
            {
                currentStateDuration += Time.deltaTime;

                if (currentStateDuration >= stateStableDuration || pinValue == 510f)
                {
                    if (pinValue >= drumRangeLower && pinValue <= drumRangeUpper)
                    {
                        currentPinState = targetState; // Drum
                    }
                    else if (pinValue >= pianoRangeLower && pinValue <= pianoRangeUpper)
                    {
                        currentPinState = targetState + 1; // Piano
                    }
                    else if (pinValue >= partyDrumRangeLower && pinValue <= partyDrumRangeUpper)
                    {
                        currentPinState = targetState + 2; // Party Drum
                    }
                    else if (pinValue >= partyPianoRangeLower && pinValue <= partyPianoRangeUpper)
                    {
                        currentPinState = targetState + 3; // Party Piano
                    }
                    valueText.text = currentPinState.ToString();
                }
            }
            else
            {
                currentStateDuration = 0f;
                valueText.text = "Pending";
                // Reset state to 0 only if it's not already 0
                if (currentPinState != 0)
                {
                    currentPinState = 0;
                }
            }

            lastPinValue = pinValue;
        }
    }
}
