using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : MonoBehaviour
{
    public GameObject objectToShrink;
    private Vector3 originalScale;
    private bool isShrinking = false;
    private float shrinkSpeed = 6.0f; // Adjust the speed of shrinking

    void Start()
    {
        // Store the original scale of the object
        originalScale = objectToShrink.transform.localScale;
    }

    void Update()
    {
        
        // Check if currently shrinking
        if (isShrinking)
        {
            // Shrink the object by 20% of its original size
            objectToShrink.transform.localScale -= originalScale * 0.2f * shrinkSpeed * Time.deltaTime;

            // Check if the object has shrunk by 20%
            if (objectToShrink.transform.localScale.x <= originalScale.x * 0.8f)
            {
                // End the shrinking effect
                EndShrinkEffect();
            }
        }
    }

    public void StartShrinkEffect()
    {
        // Reset the scale of the object before starting the shrink effect
        objectToShrink.transform.localScale = originalScale;
        isShrinking = true;
    }

    void EndShrinkEffect()
    {
        // Reset the scale of the object to its original size
        objectToShrink.transform.localScale = originalScale;
        isShrinking = false;
    }
}
