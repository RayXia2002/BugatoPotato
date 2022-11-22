using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance =  GameObject.Find("GameManager").GetComponent<GameManager>();
            }
            if(_instance == null)
            {
                _instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return _instance;
        }
    }
    public int day { get; set; }
    public float plantHealth { get; set; }
    public float plantMaxHealth { get; set; }
    public float playerHealth { get; set; }
    public int playerMaxHealth { get; set; }
    public bool plantChange { get; set;}
    public DayNightController dnc;
    public ShopController sc;
    public TutorialController tc;
    public GameObject tutorialHUD;
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
    public GameObject pauseScreen;
    
    public float bugsOnScreen;
    public bool firstDay = true;
    public bool setUp;
    private bool pause = false;
    
    void Update()
    {
        day = dnc.numOfDays;
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
            plantMaxHealth += 10;
            plantChange = true;
            shoot.meterValue = shoot.maxMeterValue;
            pb.healthHearts.SetHearts(6, 3);
            pb.health = 6;
            dnc.lengthOfCycle = 0.015f;
            sc.potatoes += 5;
            dnc.nightTime = false;
            bs.spawn = false;
            sc.OpenShop();
            dale.SetActive(false);
            tutorialHUD.SetActive(false);
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

        if (tc.stage == 2)
        {
            bs.spawn = true;
            tc.stage++;
        }
        // if(Input.GetKeyDown("p"))
        // {
        //     PauseGame();
        // }
    }
    void Awake()
    {
        day = 1;
        plantHealth = 10f;
        plantMaxHealth = 10f;
        playerHealth = 6;
        playerMaxHealth = 3;
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
        caterBehavior.speed = 1.5f;
        
        shoot.canFire = true;
        dnc.dayIdle = false;
        sc.CloseShop();
        shoot.canFire = true;
        
        Debug.Log(GameValues.toggleTutorial);
        // if tutu is toggled on set display to true
        if (GameValues.toggleTutorial)
        {
            
            tutorialHUD.SetActive(true);
            tc.DisplayTutorial(true);
            tc.stage = 0;
            TutorialPause();
        }
        // else set display to false
        else
        {
            tc.DisplayTutorial(false);
            tc.stage = -1;
            bs.spawn = true;
        }
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
        if (pb.health <= 0 || plantHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void TutorialPause()
    {
        bs.spawn = false;
    }
}
