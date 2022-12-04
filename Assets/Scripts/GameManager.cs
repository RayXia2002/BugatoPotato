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

    // plant variables
    public float plantHealth { get; set; }
    public float plantMaxHealth { get; set; }
    public bool plantChange { get; set;}

    // player variables
    public float playerHealth { get; set; }
    public int playerMaxHealth { get; set; }
    
    // potato variables
    public float extraPotatoes { get; set; }
    public float potatoes { get; set; }

    // upgrade variables
    public float commonUpgradeRate { get; set; }
    public float rareUpgradeRate { get; set; }
    public float epicUpgradeRate { get; set; }

    //bullet variables
    public Vector3 bulletSize;
    public float bulletSpeed;
    public float bulletDamage;
    public bool splitShot;

    //bug variables
    public float bugHealthCater;
    public float bugHealthBeatle;
    public float bugHealthFly;
    public float bugHealthHornet;
    
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
            
    
            plantChange = true;
            shoot.meterValue = shoot.maxMeterValue;
            pb.healthHearts.SetHearts(6, 3);
            pb.health = 6;
            dnc.lengthOfCycle = 0.015f;
            dnc.nightTime = false;
            bs.spawn = false;
            sc.OpenShop();
            //dale.SetActive(false);
            Time.timeScale = 0;
            tutorialHUD.SetActive(false);
            shoot.canFire = false;
            setUp = true;
            //dnc.dayStatus.SetPotatoRate(extraPotatoes);
        }
        if (dnc.time > 0.65f)
        {
            bs.spawn = false;

            if (bugsOnScreen <= 0 && setUp == true){
                dnc.nightTime = true;  
                setUp = false;     
                potatoes += extraPotatoes;        
            }
        }

        if (tc.stage == 2)
        {
            bs.spawn = true;
            tc.stage++;
            dnc.setPause(false);
        }
    }
    void Awake()
    {
        day = 1;
        extraPotatoes += 5f;
        plantHealth = 10f;
        plantMaxHealth = 10f;
        playerHealth = 6;
        playerMaxHealth = 3;
        startDayButton.onClick.AddListener(StartDay);   
        setUp = true;
    }

    public void StartDay()
    {
        dnc.dayIdle = false;
        sc.CloseShop();
        //dale.SetActive(true);
        Time.timeScale = 1;
        shoot.canFire = true;
        bs.spawn = true;
    }

    public void StartFirstDay()
    {
        commonUpgradeRate = 100f;
        rareUpgradeRate = 0f;
        epicUpgradeRate = 0f;
        flyBehavior.speed = 0.75f;
        beetleBehavior.speed = 0.4f;
        caterBehavior.speed = 1.5f;
        
        shoot.canFire = true;
        dnc.dayIdle = false;
        sc.CloseShop();
        shoot.canFire = true;
        
        // if tutu is toggled on set display to true
        if (GameValues.toggleTutorial)
        {
            tutorialHUD.SetActive(true);
            tc.DisplayTutorial(true);
            tc.stage = 0;
            dnc.setPause(true);
            TutorialPause();
        }
        // else set display to false
        else
        {
            tc.DisplayTutorial(false);
            dnc.setPause(false);
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

    public void UpgradePlantHealth(float val) {
        plantMaxHealth += val;
        plantHealth += val;
    }

    public void UpgradePlayerHealth(int val) {
        playerMaxHealth += val;
    }

    public void UpgradePotatoOutput(int val) {
        extraPotatoes += val;
    }
}
