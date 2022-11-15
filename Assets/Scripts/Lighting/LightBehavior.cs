using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehavior : MonoBehaviour, DayNightInterface
{
    public Gradient gradient;
    public UnityEngine.Rendering.Universal.Light2D light;

    public void SetParameter(float time)
    {
        light.color = gradient.Evaluate(time);
    }
}
