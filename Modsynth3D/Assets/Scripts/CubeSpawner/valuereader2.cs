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

    private const float stateStableDuration = 5f; // Time in seconds to consider the state stable
    private const float blockChangeDelay = 5f; // Delay in seconds before allowing block change

    void Update()
    {
        UpdatePinState(ref currentStateDuration1, ref lastPin1Value, ref currentPin1State, Pin1, ref value1, 184, 198, 199, 260, 130, 153, 154, 183, 2);
        UpdatePinState(ref currentStateDuration2, ref lastPin2Value, ref currentPin2State, Pin2, ref value2, 179, 203, 204, 220, 130, 153, 154, 178, 2);
        UpdatePinState(ref currentStateDuration3, ref lastPin3Value, ref currentPin3State, Pin3, ref value3, 189, 200, 201, 255, 130, 159, 160, 180, 2);
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

                if (currentStateDuration >= stateStableDuration)
                {
                    if (pinValue >= drumRangeLower && pinValue <= drumRangeUpper)
                    {
                        if (currentPinState != targetState)
                        {
                            currentPinState = targetState; // Drum
                            valueText.text = currentPinState.ToString();
                        }
                    }
                    else if (pinValue >= pianoRangeLower && pinValue <= pianoRangeUpper)
                    {
                        if (currentPinState != targetState + 1)
                        {
                            currentPinState = targetState + 1; // Piano
                            valueText.text = currentPinState.ToString();
                        }
                    }
                    else if (pinValue >= partyDrumRangeLower && pinValue <= partyDrumRangeUpper)
                    {
                        if (currentPinState != targetState + 2)
                        {
                            currentPinState = targetState + 2; // Party Drum
                            valueText.text = currentPinState.ToString();
                        }
                    }
                    else if (pinValue >= partyPianoRangeLower && pinValue <= partyPianoRangeUpper)
                    {
                        if (currentPinState != targetState + 3)
                        {
                            currentPinState = targetState + 3; // Party Piano
                            valueText.text = currentPinState.ToString();
                        }
                    }
                }
            }
            else
            {
                currentStateDuration = 0f;
                valueText.text = "Pending";
            }

            lastPinValue = pinValue;
        }
    }
}
