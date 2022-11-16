using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{

    public DayNightController dnc;
    public Image[] images;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dnc.getDays() == 1)
        {
            updateImages(true);
        }
        else
        {
            updateImages(false);
        }
    }

    void updateImages(bool onOff)
    {
        for (int i = 0; i < 4; i++)
        {
            images[i].enabled = onOff;
        }
    }
}
