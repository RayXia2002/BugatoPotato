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
    //public Button upgradeButton1, upgradeButton2, upgradeButton3, startDayButton;
    public GameObject upgradeSpeedCard1;
    public GameObject upgradeBulletSpeedCard1;
    public GameObject upgradeFireRateCard1;
    public GameObject upgradeRefillTimerCard1;
    public GameObject storeUI;
    public GameObject cardSpot1;
    public GameObject cardSpot;
    GameObject card1;
    GameObject card2;
    GameObject card3;
    
    // Start is called before the first frame update
    void Start()
    {
        
        potatoesTxt.text = potatoes.ToString();
        //upgradeButton1.onClick.AddListener(PurchaseUpgrade1);
        //upgradeButton2.onClick.AddListener(PurchaseUpgrade2);
        //upgradeButton3.onClick.AddListener(PurchaseUpgrade3);
    }

    // Update is called once per frame
    void Update()
    {
       potatoesTxt.text = potatoes.ToString();
       potatoesTxtHud.text = potatoes.ToString();
    }

    public void CardSlot1()
    {
        Vector3 spot = new Vector3(0, 0, 0);
        card1 = Instantiate(upgradeSpeedCard1, spot, Quaternion.identity);
        card2 = Instantiate(upgradeRefillTimerCard1, spot, Quaternion.identity);
        card3 = Instantiate(upgradeFireRateCard1, spot, Quaternion.identity);
        card1.transform.SetParent(cardSpot.transform);
        card1.transform.localScale = new Vector3(1,1,1);
        card2.transform.SetParent(cardSpot.transform);
        card2.transform.localScale = new Vector3(1,1,1);
        card3.transform.SetParent(cardSpot.transform);
        card3.transform.localScale = new Vector3(1,1,1);
        
    }

    public void PurchaseSpeed1()
    {
        if (potatoes >= 5)
        {
            potatoes -= 5;
            upgradeController.UpgradePlayerSpeed(); 
            //card1.transform.GetChild(1).gameObject.SetActive(false);
            upgradeSpeedCard1.transform.GetChild(1).gameObject.SetActive(false);
            //upgradeSpeedCard1.SetActive(false);
        }
    }

    public void PurchaseRefill1()
    {
        if (potatoes >= 5)
        {
            potatoes -= 5;
            upgradeController.UpgradeRefillTimer();
            //card2.transform.GetChild(1).gameObject.SetActive(false);   
            upgradeRefillTimerCard1.transform.GetChild(1).gameObject.SetActive(false);
        }

    }

    public void PurchaseFireRate1()
    {
        if (potatoes >= 5)
        {
            potatoes -= 5;
            upgradeController.UpgradeFireRate();
            //card3.transform.GetChild(1).gameObject.SetActive(false);
            upgradeFireRateCard1.transform.GetChild(1).gameObject.SetActive(false);
        }

    }

    public void CloseShop()
    {
        //upgradeCard1.SetActive(true);
        //upgradeCard2.SetActive(true);
        //upgradeCard3.SetActive(true);
        storeUI.SetActive(false);
    }

    public void OpenShop()
    {
        storeUI.SetActive(true);
        //CardSlot1();
    }
}
