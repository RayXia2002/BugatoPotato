using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBehavior : MonoBehaviour, IDamageable
{
    public float health { get; set; }
    public HealthBar healthBar;
    public GameObject stageOne, stageTwo, stageThree, stageFour, stageFive;
   

    public void OnHit(float damage)
    {
        GameManager.Instance.plantHealth -= damage;
        healthBar.SetHealth(GameManager.Instance.plantHealth);
        Debug.Log(GameManager.Instance.plantHealth);
        Debug.Log(damage);
    }
 
    void Start()
    {
        health = GameManager.Instance.plantHealth;
        healthBar.SetMaxHealth(health);
    }

    void Update()
    {
        
        healthBar.SetHealth(GameManager.Instance.plantHealth);
        if (GameManager.Instance.plantChange)
        {
            ChangePlantStage((PlantStage)GameManager.Instance.day);
            GameManager.Instance.plantChange = false;
        }

    }

    public void ChangePlantStage(PlantStage day)
    {
        health = GameManager.Instance.plantHealth;
        if (day == PlantStage.StageOne)
        {
            healthBar.SetHealth(health);
            healthBar.SetMaxHealth(health);
            stageOne.SetActive(true);
        }
        if (day == PlantStage.StageTwo)
        {
            healthBar.SetHealth((health + 10f));
            healthBar.SetMaxHealth(20f);
            stageOne.SetActive(false);
            stageTwo.SetActive(true);
        }
        if (day == PlantStage.StageThree)
        {
            healthBar.SetHealth((health + 10f));
            healthBar.SetMaxHealth(30f);
            stageTwo.SetActive(false);
            stageThree.SetActive(true);
        }
        if (day == PlantStage.StageFour)
        {
            healthBar.SetHealth((health + 10f));
            healthBar.SetMaxHealth(40f);
            stageThree.SetActive(false);
            stageFour.SetActive(true);
        }
        if (day == PlantStage.StageFive)
        {
            healthBar.SetHealth((health + 10f));
            healthBar.SetMaxHealth(50f);
            stageFour.SetActive(false);
            stageFive.SetActive(true);
        }
    }

    public enum PlantStage
    {
        StageOne = 1,
        StageTwo = 2,
        StageThree = 3,
        StageFour = 4,
        StageFive = 5
    }

}
