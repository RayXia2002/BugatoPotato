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
        healthBar.SetMaxHealth(GameManager.Instance.plantMaxHealth);
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
        GameManager.Instance.plantHealth += 10f;
        health = GameManager.Instance.plantHealth;
        if (day == PlantStage.StageOne)
        {
            healthBar.SetMaxHealth(health);
            healthBar.SetHealth(health);
            stageOne.SetActive(true);
        }
        if (day == PlantStage.StageTwo)
        {
            GameManager.Instance.extraPotatoes += 3f;
            healthBar.SetMaxHealth(GameManager.Instance.plantMaxHealth);
            healthBar.SetHealth(health);
            stageOne.SetActive(false);
            stageTwo.SetActive(true);
        }
        if (day == PlantStage.StageThree)
        {
            GameManager.Instance.extraPotatoes += 3f;
            healthBar.SetMaxHealth(GameManager.Instance.plantMaxHealth);
            healthBar.SetHealth(health);
            stageTwo.SetActive(false);
            stageThree.SetActive(true);
        }
        if (day == PlantStage.StageFour)
        {
            GameManager.Instance.extraPotatoes += 3f;
            healthBar.SetMaxHealth(GameManager.Instance.plantMaxHealth);
            healthBar.SetHealth(health);
            stageThree.SetActive(false);
            stageFour.SetActive(true);
        }
        if (day == PlantStage.StageFive)
        {
            GameManager.Instance.extraPotatoes += 3f;
            healthBar.SetMaxHealth(GameManager.Instance.plantMaxHealth);
            healthBar.SetHealth(health);
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
