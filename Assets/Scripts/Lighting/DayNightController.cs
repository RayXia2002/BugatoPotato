using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface DayNightInterface
{
    void SetParameter(float time);
}

public class DayNightController : MonoBehaviour
{
    public DayStatus dayStatus;
    //[Range(0,1)]
    public float time;
    public DayNightInterface[] lights;
    public bool day;
    public float lengthOfCycle = 0.015f;
    public float numOfDays = 1;

    void Start()
    {
        time = 0;
        day = true;
        dayStatus.SetDay(numOfDays);
        GetSetters();

    }

    // Update is called once per frame
    void Update()
    {
        if (lights.Length > 0)
        {
            foreach (var light in lights)
            {
                light.SetParameter(time);
            }
        }

        if (time > 0.65f)
        {
            day = false;            
        }
        else if (time <= 0f)
        {
            day = true;
        }
        
        if (day)
        {
            time = Mathf.Lerp(time, 1.1f, Time.smoothDeltaTime * lengthOfCycle);
        }
        else if (!day)
        {
            time = 0f;
            ++numOfDays;
            dayStatus.SetDay(numOfDays);
        }

    }

    private void GetSetters()
    {
        lights = GetComponentsInChildren<DayNightInterface>();
    }
}
