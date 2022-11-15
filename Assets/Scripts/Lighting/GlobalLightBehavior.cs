using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalLightBehavior : MonoBehaviour, DayNightInterface
{
    public Gradient gradient;
    public UnityEngine.Rendering.Universal.Light2D light;

    public void SetParameter(float time)
    {
        light.color = gradient.Evaluate(time);
        light.intensity = (1f - time);
    }
}

