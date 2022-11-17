using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public DayNightController dnc;
    public ShopController sc;
    public BugSpawner bs;
    public PlayerBehavior pb;
    public Shoot shoot;
    public PlantBehavior plantBehavior;
    public CaterBehave caterBehavior;
    public BeetleBehave beetleBehavior;
    public FlyBehave flyBehavior;
    public Button startDayButton;
    public GameObject dale;
    public GameObject bulletSpawner;
    

    public float bugsOnScreen;
    public bool firstDay = true;
    public bool setUp;
    
    void Update()
    {
        CheckForDeath();
        CountBugs();
        if (firstDay == true)
        {
            StartFirstDay();
            dnc.lengthOfCycle = 0.03f;
            firstDay = false;
        }
        if (dnc.dayIdle == true && !firstDay && !setUp)
        {
            if (dnc.numOfDays <= 11){
                bs.spawnRate -= (0.03f * dnc.numOfDays);
                flyBehavior.speed += (0.009f * dnc.numOfDays);
                caterBehavior.speed += (0.009f * dnc.numOfDays);
                beetleBehavior.speed += (0.009f * dnc.numOfDays);   
            }
            shoot.meterValue = shoot.maxMeterValue;
            pb.healthHearts.SetHearts(6, 3);
            plantBehavior.health = 100f;
            dnc.lengthOfCycle = 0.015f;
            sc.potatoes += 5;
            dnc.nightTime = false;
            bs.spawn = false;
            sc.OpenShop();
            dale.SetActive(false);
            shoot.canFire = false;
            setUp = true;
        }
        if (dnc.time > 0.65f)
        {
            bs.spawn = false;
            if (bugsOnScreen <= 0){
                dnc.nightTime = true;  
                setUp = false;             
            }
        }
    }

    void Start()
    {
        startDayButton.onClick.AddListener(StartDay);
        
    }


    public void StartDay()
    {
        dnc.dayIdle = false;
        sc.CloseShop();
        dale.SetActive(true);
        shoot.canFire = true;
        bs.spawn = true;
    }

    public void StartFirstDay()
    {
        flyBehavior.speed = 0.75f;
        beetleBehavior.speed = 0.4f;
        caterBehavior.speed = 0.2f;
        dnc.dayIdle = false;
        sc.CloseShop();
        dale.SetActive(true);
        shoot.canFire = true;
        bs.spawn = true;
    }

    private void CountBugs()
    {
        GameObject[] bugs = GameObject.FindGameObjectsWithTag("bug");
        var count = 0;    
        foreach(GameObject bug in bugs)
        {
            count++;
        }
        bugsOnScreen = count;
    }

    private void CheckForDeath()
    {
        if (pb.health <= 0 || plantBehavior.health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
