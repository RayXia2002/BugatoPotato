using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBehavior : MonoBehaviour, IDamageable
{
    public float Health { get; set; }
    public HealthBar healthBar;

    public void OnHit(float damage)
    {
        Health -= damage;
        healthBar.SetHealth(Health);
    }
 
    void Start()
    {
        Health = 100f;
        healthBar.SetMaxHealth(Health);
    }

    void Update()
    {
        healthBar.SetHealth(Health);
    }

}
