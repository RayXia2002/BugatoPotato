using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayStatus : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI dayStatus;

    public void SetDay(float day)
    {
        dayStatus.text = $"Day {day.ToString()}";
    }
}
