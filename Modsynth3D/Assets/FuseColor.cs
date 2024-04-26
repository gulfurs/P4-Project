using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseColor : MonoBehaviour
{
    private Renderer cubeRenderer;
    private float hue;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        hue = (hue + Time.deltaTime * 0.2f) % 1f;

        Color color = Color.HSVToRGB(hue, 1f, 1f);

        cubeRenderer.material.color = color;
    }
}
