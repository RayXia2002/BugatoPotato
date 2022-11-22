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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateT(bool o)
    {
        GameValues.toggleTutorial = o;
        Debug.Log(GameValues.toggleTutorial);
    }
}
