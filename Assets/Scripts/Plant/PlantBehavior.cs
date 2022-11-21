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
        health -= damage;
        healthBar.SetHealth(health);
    }
 
    void Start()
    {
        
        health = GameManager.Instance.plantHealth;
        Debug.Log(health);
        healthBar.SetMaxHealth(health);
    }

    void Update()
    {
        healthBar.SetHealth(health);
        ChangePlantStage((PlantStage)GameManager.Instance.day);
    }

    public void ChangePlantStage(PlantStage day)
    {
        if (day == PlantStage.StageOne)
        {
            stageOne.SetActive(true);
        }
        if (day == PlantStage.StageTwo)
        {
            stageOne.SetActive(false);
            stageTwo.SetActive(true);
        }
        if (day == PlantStage.StageThree)
        {
            stageTwo.SetActive(false);
            stageThree.SetActive(true);
        }
        if (day == PlantStage.StageFour)
        {
            stageThree.SetActive(false);
            stageFour.SetActive(true);
        }
        if (day == PlantStage.StageFive)
        {
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
