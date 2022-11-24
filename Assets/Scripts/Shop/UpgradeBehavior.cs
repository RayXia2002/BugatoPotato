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

    public void TestFunction()
    {
        Debug.Log("testing");
    }

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
}
