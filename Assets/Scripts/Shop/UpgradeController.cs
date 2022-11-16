using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Bullet bullet;
    private Shoot shoot;
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        bullet = GetComponent<Bullet>();
        shoot = GetComponent<Shoot>();
    }

    public void UpgradePlayerSpeed() {
        playerMovement.UpgradePlayerSpeed(0.5f);
    }
    public void UpgradeBulletSpeed() {
        bullet.UpgradeBulletSpeed(50.0f);
    }
    public void UpgradeFireRate() {
        shoot.UpgradeFireRate(-0.1f);
    }

    public void UpgradeRefillTimer() {
        shoot.UpgradeRefillTimer(-0.1f);
    }
}
