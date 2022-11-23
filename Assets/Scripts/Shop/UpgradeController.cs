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

    public void UpgradePlayerSpeed1() {
        playerMovement.UpgradePlayerSpeed(0.5f);
    }

    public void UpgradePlayerSpeed2() {
        playerMovement.UpgradePlayerSpeed(0.75f);
    }

    public void UpgradePlayerSpeed3() {
        playerMovement.UpgradePlayerSpeed(1f);
    }

    public void UpgradeBulletSpeed1() {
        bullet.UpgradeBulletSpeed(50.0f);
    }

    public void UpgradeBulletSpeed2() {
        bullet.UpgradeBulletSpeed(75.0f);
    }

    public void UpgradeBulletSpeed3() {
        bullet.UpgradeBulletSpeed(100.0f);
    }

    public void UpgradeFireRate1() {
        shoot.UpgradeFireRate(0.01f);
    }

    public void UpgradeFireRate2() {
        shoot.UpgradeFireRate(0.02f);
    }

    public void UpgradeFireRate3() {
        shoot.UpgradeFireRate(0.03f);
    }

    public void UpgradeRefillTimer1() {
        shoot.UpgradeRefillTimer(0.1f);
    }

    public void UpgradeRefillTimer2() {
        shoot.UpgradeRefillTimer(0.2f);
    }

    public void UpgradeRefillTimer3() {
        shoot.UpgradeRefillTimer(0.3f);
    }

}
