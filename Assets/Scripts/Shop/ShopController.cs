using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopController : MonoBehaviour
{
    public float potatoes;
    public TextMeshProUGUI potatoesTxt;
    public TextMeshProUGUI potatoesTxtHud;
    public UpgradeController upgradeController;
    public Button upgradeButton1, upgradeButton2, upgradeButton3, startDayButton;
    public GameObject upgradeCard1;
    public GameObject upgradeCard2;
    public GameObject upgradeCard3;
    public GameObject storeUI;
    // Start is called before the first frame update
    void Start()
    {
        
        potatoesTxt.text = potatoes.ToString();
        upgradeButton1.onClick.AddListener(PurchaseUpgrade1);
        upgradeButton2.onClick.AddListener(PurchaseUpgrade2);
        upgradeButton3.onClick.AddListener(PurchaseUpgrade3);
    }

    // Update is called once per frame
    void Update()
    {
       potatoesTxt.text = potatoes.ToString();
       potatoesTxtHud.text = potatoes.ToString();
    }

    public void PurchaseUpgrade1()
    {
        if (potatoes >= 5)
        {
            potatoes -= 5;
            upgradeController.UpgradePlayerSpeed(); 
            upgradeCard1.SetActive(false);
        }
    }

    public void PurchaseUpgrade2()
    {
        if (potatoes >= 5)
        {
            potatoes -= 5;
            upgradeController.UpgradeRefillTimer();
            upgradeCard2.SetActive(false);      
        }

    }

    public void PurchaseUpgrade3()
    {
        if (potatoes >= 5)
        {
            potatoes -= 5;
            upgradeController.UpgradeFireRate();
            upgradeCard3.SetActive(false);
        }

    }

    public void CloseShop()
    {
        upgradeCard1.SetActive(true);
        upgradeCard2.SetActive(true);
        upgradeCard3.SetActive(true);
        storeUI.SetActive(false);
    }

    public void OpenShop()
    {
        storeUI.SetActive(true);
    }
}
