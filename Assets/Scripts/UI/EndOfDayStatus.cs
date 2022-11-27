using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndOfDayStatus : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI dayStatus;
    [SerializeField]
    private TextMeshProUGUI potatoStatus;
    [SerializeField]
    private TextMeshProUGUI potatoRateStatus;

    public void SetDay(float day)
    {
        dayStatus.text = $"Day {day.ToString()}";
    }

    public void SetPotato(float potato)
    {
        potatoStatus.text = $"{potato.ToString()}";
    }
    
    public void SetPotatoRate(float potatoRate)
    {
        potatoRateStatus.text = $"{potatoRate.ToString()}";
    }
}

