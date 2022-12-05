using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PotatoStatus : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI potatoRateStatus;

    void Update()
    {
        potatoRateStatus.text = GameManager.Instance.extraPotatoes.ToString();
    }
}
