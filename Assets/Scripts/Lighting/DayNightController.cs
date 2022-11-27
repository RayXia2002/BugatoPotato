using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public interface DayNightInterface
{
    void SetParameter(float time);
}

public class DayNightController : MonoBehaviour
{
    
    public DayStatus dayStatus;
    public EndOfDayStatus endOfDayStatus;
    //[Range(0,1)]
    public float time;
    public DayNightInterface[] lights;
    public GameObject fireFlies;
    public GameObject endOfDay;
    public bool day;
    public bool dayIdle;
    public bool nightTime;
    public float lengthOfCycle = 0.015f;
    public int numOfDays = 1;
    public bool pause = false;
    private bool nextDay = false;
    private bool showDayPanel = true;



    void Start()
    {
        time = 0;
        day = true;
        dayIdle = true;
        nightTime = false;
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
        
        if (day && !dayIdle && !pause)
        {
            time = Mathf.Lerp(time, 1.1f, Time.smoothDeltaTime * lengthOfCycle);
        }
        else if (!day && nightTime == true)
        {
            if (time <= 1f && !nextDay)
            {
                time = Mathf.Lerp(time, 1.1f, Time.smoothDeltaTime * 1f);   
            }

            if (time >= 1f && showDayPanel)
            {
                IEnumerator coroutine = ShowEndOfDay();
                StartCoroutine(coroutine);

            }
            if (time <= 0)
            {
                ++numOfDays;
                nextDay = false;
                day = true;
                dayIdle = true;
                showDayPanel = true;
                //time = 0f;
                dayStatus.SetDay(numOfDays);
            }
        }

        if (nextDay)
        {
            time = Mathf.Lerp(time, -0.1f, Time.smoothDeltaTime * 3f);   
        }

        if (time < 0.55f)
        {
            fireFlies.SetActive(false);
        }
        else if (time > 0.55f)
        {
            fireFlies.SetActive(true);
        }

    }

    private IEnumerator ShowEndOfDay()
    {
        showDayPanel = false;
        //Debug.Log("how often does this get called");
        //++numOfDays;
        endOfDayStatus.SetDay(numOfDays);
        endOfDayStatus.SetPotato(GameManager.Instance.potatoes);
        endOfDayStatus.SetPotatoRate(GameManager.Instance.extraPotatoes);
        endOfDay.SetActive(true);
        yield return new WaitForSeconds(3f);
        endOfDay.SetActive(false);
        nextDay = true;
    }

    private void GetSetters()
    {
        lights = GetComponentsInChildren<DayNightInterface>();
    }

    public int getDays()
    {
        return numOfDays;
    }

    public void setPause(bool isPause)
    {
        pause = isPause;
    }
}
