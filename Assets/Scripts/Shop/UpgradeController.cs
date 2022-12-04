using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Bullet bullet;
    public Shoot shoot;
    public GameManager gameManager;
    public ShopController shopController;
    void Start()
    {
        //playerMovement = GetComponent<PlayerMovement>();
        //bullet = GetComponent<Bullet>();
        //shoot = GetComponent<Shoot>();
    }

    #region Upgrade Player Speed
    public void UpgradePlayerSpeed1() {
        playerMovement.UpgradePlayerSpeed(0.5f);
    }
    public void UpgradePlayerSpeed2() {
        playerMovement.UpgradePlayerSpeed(0.75f);
    }
    public void UpgradePlayerSpeed3() {
        playerMovement.UpgradePlayerSpeed(1f);
    }
    #endregion Upgrade Player Speed

    #region Upgrade Bullet Speed
    public void UpgradeBulletSpeed1() {
        bullet.UpgradeBulletSpeed(50.0f);
    }
    public void UpgradeBulletSpeed2() {
        bullet.UpgradeBulletSpeed(75.0f);
    }
    public void UpgradeBulletSpeed3() {
        bullet.UpgradeBulletSpeed(100.0f);
    }
    #endregion Upgrade Bullet Speed

    #region Upgrade Firerate
    public void UpgradeFireRate1() {
        shoot.UpgradeFireRate(0.01f);
    }
    public void UpgradeFireRate2() {
        shoot.UpgradeFireRate(0.02f);
    }
    public void UpgradeFireRate3() {
        shoot.UpgradeFireRate(0.03f);
    }
    #endregion Upgrade Firerate

    #region Upgrade Refill Timer
    public void UpgradeRefillTimer1() {
        shoot.UpgradeRefillTimer(0.1f);
    }
    public void UpgradeRefillTimer2() {
        shoot.UpgradeRefillTimer(0.2f);
    }
    public void UpgradeRefillTimer3() {
        shoot.UpgradeRefillTimer(0.3f);
    }
    #endregion Upgrade Refill Timer

    #region Upgrade Bullet Damage
    public void UpgradeBulletDamage1() {
        bullet.UpgradeBulletDamage(2f);
    }
    public void UpgradeBulletDamage2() {
        bullet.UpgradeBulletDamage(5f);
    }
    public void UpgradeBulletDamage3() {
        bullet.UpgradeBulletDamage(10f);
    }
    #endregion Upgrade Bullet Damage
    
    #region Upgrade Plant Health
    public void UpgradePlantHealth1() {
        gameManager.UpgradePlantHealth(2f);
    }
    public void UpgradePlantHealth2() {
        gameManager.UpgradePlantHealth(4f);
    }
    public void UpgradePlantHealth3() {
        gameManager.UpgradePlantHealth(10f);
    }
    #endregion Upgrade Plant Health
    
    #region Upgrade Player Health
    public void UpgradePlayerHealth1() {
        gameManager.UpgradePlayerHealth(1);
    }
    public void UpgradePlayerHealth2() {
        gameManager.UpgradePlayerHealth(2);
    }
    public void UpgradePlayerHealth3() {
        gameManager.UpgradePlayerHealth(3);
    }
    #endregion Upgrade Player Health

    #region Upgrade Potato Output
    public void UpgradePotatoOutput1() {
        gameManager.UpgradePotatoOutput(2);
    }
    public void UpgradePotatoOutput2() {
        gameManager.UpgradePotatoOutput(4);
    }
    public void UpgradePotatoOutput3() {
        gameManager.UpgradePotatoOutput(7);
    }
    #endregion Upgrade Potato Output

    #region Upgrade Double Jump
    public void UpgradeDoubleJump() {
        playerMovement.UpgradeDoubleJump();
    }
    #endregion Upgrade Double Jump
    
    #region Upgrade SplitShot
    public void UpgradeSplitShot()
    {
        GameManager.Instance.splitShot = true;
        shopController.RemoveSplitShot();
    }
    #endregion Upgrade SplitShot

    #region Upgrade BigBullets
    public void UpgradeBigBullets()
    {
        GameManager.Instance.bulletSize += new Vector3(5f,5f,5f);
        GameManager.Instance.bulletSpeed = GameManager.Instance.bulletSpeed / 2f;
    }
    #endregion Upgrade BigBullets
}
