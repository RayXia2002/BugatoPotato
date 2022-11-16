using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Bullet bullet;
    public Shoot shoot;
    void Start()
    {
        //playerMovement = GetComponent<PlayerMovement>();
        //bullet = GetComponent<Bullet>();
        //shoot = GetComponent<Shoot>();
    }

    public void UpgradePlayerSpeed() {
        playerMovement.UpgradePlayerSpeed(0.5f);
    }
    public void UpgradeBulletSpeed() {
        bullet.UpgradeBulletSpeed(50.0f);
    }
    public void UpgradeFireRate() {
        shoot.UpgradeFireRate(0.05f);
    }

    public void UpgradeRefillTimer() {
        shoot.UpgradeRefillTimer(0.1f);
    }

}
