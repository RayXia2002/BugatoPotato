using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBehavior : MonoBehaviour, IDamageable
{
    public float health { get; set; }
    public HealthBar healthBar;

    public void OnHit(float damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
    }
 
    void Start()
    {
        health = 100f;
        healthBar.SetMaxHealth(health);
    }

    void Update()
    {
        healthBar.SetHealth(health);
    }

}
