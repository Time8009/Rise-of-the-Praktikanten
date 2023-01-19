using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class ColorChangeExtension : MonoBehaviour
{
    private Light light;

    [SerializeField]
    private Renderer Lamp;

    [SerializeField]
    private Color StartColor = Color.white;

    [SerializeField]
    private Color EndColor = Color.white;

    [SerializeField]
    private int colorChangeSpeed = 5;

    private Color targetColor;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        light.color = StartColor;
        targetColor = EndColor;

    }

    // Update is called once per frame
    void Update()
    {
        light.color = Color.LerpUnclamped(light.color, targetColor, Time.deltaTime * 0.1f * colorChangeSpeed);

        if (Lamp != null)
        {
            Lamp.material.color = light.color;
            Lamp.material.SetColor("_EmissionColor", light.color);
        }

        if(light.color == targetColor)
        {
            if (targetColor == StartColor)
                targetColor = EndColor;
            else
                targetColor = StartColor;
        }
    }
}
