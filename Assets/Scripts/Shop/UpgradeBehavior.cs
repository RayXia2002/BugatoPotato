using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBehavior : MonoBehaviour
{
    //public UpgradeController upgradeController;
    public UpgradeController upgradeController;
    public float rarity;

    void Start()
    {
        upgradeController = GameObject.FindObjectOfType<UpgradeController>();
    }

    #region Purchase Speed
    public void PurchaseSpeed1()
    {
        if (GameManager.Instance.potatoes >= 5)
        {
            GameManager.Instance.potatoes  -= 5;
            upgradeController.UpgradePlayerSpeed1(); 
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    public void PurchaseSpeed2()
    {
        if (GameManager.Instance.potatoes >= 8)
        {
            GameManager.Instance.potatoes  -= 8;
            upgradeController.UpgradePlayerSpeed2(); 
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    public void PurchaseSpeed3()
    {
        if (GameManager.Instance.potatoes >= 13)
        {
            GameManager.Instance.potatoes  -= 13;
            upgradeController.UpgradePlayerSpeed3(); 
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    #endregion Purchase Speed

    #region Purchase Refill
    public void PurchaseRefill1()
    {
        if (GameManager.Instance.potatoes  >= 5)
        {
            GameManager.Instance.potatoes -= 5;
            upgradeController.UpgradeRefillTimer1();
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    public void PurchaseRefill2()
    {
        if (GameManager.Instance.potatoes  >= 8)
        {
            GameManager.Instance.potatoes -= 8;
            upgradeController.UpgradeRefillTimer2();
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    public void PurchaseRefill3()
    {
        if (GameManager.Instance.potatoes  >= 13)
        {
            GameManager.Instance.potatoes -= 13;
            upgradeController.UpgradeRefillTimer3();
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    #endregion Purchase Refill

    #region Purchase Fire Rate
    public void PurchaseFireRate1()
    {
        if (GameManager.Instance.potatoes  >= 5)
        {
            GameManager.Instance.potatoes -= 5;
            upgradeController.UpgradeFireRate1();
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    public void PurchaseFireRate2()
    {
        if (GameManager.Instance.potatoes  >= 8)
        {
            GameManager.Instance.potatoes -= 8;
            upgradeController.UpgradeFireRate2();
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    public void PurchaseFireRate3()
    {
        if (GameManager.Instance.potatoes  >= 13)
        {
            GameManager.Instance.potatoes -= 13;
            upgradeController.UpgradeFireRate3();
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    #endregion Purchase Fire Rate

    #region Purchase Bullet Speed
    public void PurchaseBulletSpeed1()
    {
        if (GameManager.Instance.potatoes  >= 5)
        {
            GameManager.Instance.potatoes -= 5;
            upgradeController.UpgradeBulletSpeed1();
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    public void PurchaseBulletSpeed2()
    {
        if (GameManager.Instance.potatoes  >= 8)
        {
            GameManager.Instance.potatoes -= 8;
            upgradeController.UpgradeBulletSpeed2();
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    public void PurchaseBulletSpeed3()
    {
        if (GameManager.Instance.potatoes  >= 13)
        {
            GameManager.Instance.potatoes -= 13;
            upgradeController.UpgradeBulletSpeed3();
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    #endregion Purchase Bullet Speed

    #region Purchase Bullet Damage
    public void PurchaseBulletDamage1() {
        if (GameManager.Instance.potatoes >= 5)
        {
            GameManager.Instance.potatoes -= 5;
            upgradeController.UpgradeBulletDamage1();
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    public void PurchaseBulletDamage2() {
        if (GameManager.Instance.potatoes >= 8)
        {
            GameManager.Instance.potatoes -= 8;
            upgradeController.UpgradeBulletDamage2();
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    public void PurchaseBulletDamage3() {
        if (GameManager.Instance.potatoes >= 13)
        {
            GameManager.Instance.potatoes -= 13;
            upgradeController.UpgradeBulletDamage3();
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    #endregion Purchase Bullet Damage

    #region Purchase Plant Health
    public void PurchasePlantHealth() {
        if (GameManager.Instance.potatoes >= 8)
        {
            GameManager.Instance.potatoes -= 8;
            upgradeController.UpgradePlantHealth();
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    #endregion Purchase Plant Health

    #region Purchase Player Health
    public void PurchasePlayerHealth() {
        if (GameManager.Instance.potatoes >= 8)
        {
            GameManager.Instance.potatoes -= 8;
            upgradeController.UpgradePlayerHealth();
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    #endregion Purchase Player Health

    #region Purchase Potato Output
    public void PurchasePotatoOutput() {
        if (GameManager.Instance.potatoes >= 8)
        {
            GameManager.Instance.potatoes -= 8;
            upgradeController.UpgradePotatoOutput();
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    #endregion Purchase Potato Output

    #region Purchase Double Jump
    public void PurchaseDoubleJump() {
        if (GameManager.Instance.potatoes >= 13)
        {
            GameManager.Instance.potatoes -= 13;
            upgradeController.UpgradeDoubleJump();
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    #endregion Purchase Double Jump

    #region Purchase Split Shot
    public void PurchaseSplitShot() {
        if (GameManager.Instance.potatoes >= 13)
        {
            GameManager.Instance.potatoes -= 13;
            upgradeController.UpgradeSplitShot();
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    #endregion Purchase Split Shot

}
