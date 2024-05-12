using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Visulizer : MonoBehaviour
{
    public int numberOfSamples = 64; // Number of samples to analyze
    public Image[] visualizerBars;
    private float maxScale = 10f; // Maximum scale of the visualizer bar
    private float lerpSpeed = 5f;

    private float[] spectrumData;
    private float[] visualizerScales;
    //private AudioSource audioSource;

   // EffectHandler efectHandler;

    void Start()
    {
        spectrumData = new float[numberOfSamples];
        visualizerScales = new float[visualizerBars.Length];

        SetVisualizerPositions();

    }

    public void spectrumLaviosa(AudioSource audioSource) {
        // Get spectrum data from audio source
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);

        // Update visualizer bars
        for (int i = 0; i < visualizerBars.Length; i++)
        {
            float intensity = spectrumData[i];
            visualizerScales[i] = Mathf.Lerp(visualizerScales[i], intensity * maxScale, Time.deltaTime * lerpSpeed);
         
        }
        for (int i = 0; i < visualizerBars.Length; i++)
        {
            // Set the pivot to the bottom
            visualizerBars[i].rectTransform.pivot = new Vector2(0.5f, 0f);

            // Set the local position to the bottom
            //visualizerBars[i].rectTransform.localPosition = new Vector3(xPos, 0f, 0f);

            // Scale only in the y-direction
            Vector3 scale = visualizerBars[i].rectTransform.localScale;
            scale.y = visualizerScales[i];
            visualizerBars[i].rectTransform.localScale = scale;

            Color color = Color.Lerp(Color.blue, Color.red, visualizerScales[i] / 2);
            visualizerBars[i].color = color;
        }
        
    }
    void SetVisualizerPositions()
    {
        for (int i = 0; i < visualizerBars.Length; i++)
        {
            float xPos = i * 60f;
            visualizerBars[i].rectTransform.localPosition = new Vector3(xPos, 0f, 0f);
        }
    }
}
