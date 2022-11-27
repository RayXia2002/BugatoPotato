using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialToggle : MonoBehaviour
{
    private Toggle t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Toggle>();
        t.onValueChanged.AddListener(delegate {UpdateT(!t.isOn);});
        t.isOn = !GameValues.toggleTutorial;
    }

    void UpdateT(bool o)
    {
        GameValues.toggleTutorial = o;
    }
}
