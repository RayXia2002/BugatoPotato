using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoisonMeter : MonoBehaviour
{
    public Slider slider;

    public void SetMaxMeter(float value)
    {
        slider.maxValue = value;
        slider.value = value;
    }

    public void SetMeter(float value)
    {
        slider.value = value;
    }
}
