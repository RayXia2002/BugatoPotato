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
    public TextMeshProUGUI potatoRate;
    public UpgradeController upgradeController;
    public GameObject storeUI;
    public List<GameObject> allUpgrades;
    public List<GameObject> commonUpgrades;
    public List<GameObject> rareUpgrades;
    public List<GameObject> epicUpgrades;
    private List<GameObject> commonTemp;
    private List<GameObject> rareTemp;
    private List<GameObject> epicTemp;
    public GameObject cardArea; 
    private GameObject pickedUpgrade;
    private GameObject pickedUpgrade2;
    private GameObject pickedUpgrade3;
    // Start is called before the first frame update
    void Start()
    {
        potatoesTxt.text = potatoes.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        potatoes  = GameManager.Instance.potatoes;
        potatoesTxt.text = potatoes.ToString();
        potatoesTxtHud.text = potatoes.ToString();
        potatoRate.text = GameManager.Instance.extraPotatoes.ToString();
    }

    public void PopulateShop()
    {
        ClearCards();
        //Shuffle(allUpgrades);
        ChangeOdds(GameManager.Instance.day);
        commonTemp = new List<GameObject>(commonUpgrades);
        rareTemp = new List<GameObject>(rareUpgrades);
        epicTemp = new List<GameObject>(epicUpgrades);

        for (int i = 0; i < 3; i++)
        {
            CreateCard();
        }

    }

    public GameObject CalculateOdds()
    {
    
        float commonRate = GameManager.Instance.commonUpgradeRate;
        float rareRate = GameManager.Instance.rareUpgradeRate;
        float epicRate = GameManager.Instance.epicUpgradeRate;

        int odds = Random.Range(0,100);
        GameObject targetUpgrade;

        if (odds <= commonRate)
        {
            int rndUpgrade = Random.Range(0, commonTemp.Count);
            targetUpgrade = commonTemp[rndUpgrade];
            commonTemp.RemoveAt(rndUpgrade);
        }
        else if (odds - commonRate <= rareRate)
        {
            int rndUpgrade = Random.Range(0, rareTemp.Count);
            targetUpgrade = rareTemp[rndUpgrade];
            rareTemp.RemoveAt(rndUpgrade);           
        }
        else
        {
            int rndUpgrade = Random.Range(0, epicTemp.Count);
            targetUpgrade = epicTemp[rndUpgrade];
            epicTemp.RemoveAt(rndUpgrade);     
        }
        
        return targetUpgrade;
    }

    public void CreateCard()
    {
        pickedUpgrade = CalculateOdds();
        Vector3 spot = new Vector3(0, 0, 0);
        GameObject card = Instantiate(pickedUpgrade, spot, Quaternion.identity);
        card.transform.SetParent(cardArea.transform);
        card.transform.localScale = new Vector3(1,1,1);
    }

    public void ClearCards()
    {
        foreach(Transform t in cardArea.transform)
        {
            Destroy(t.gameObject);
        }
    }

    public void RemoveSplitShot()
    {
        epicUpgrades.RemoveAt(0);
    }

    public void Reroll()
    {
        PopulateShop();
    }

    public void ChangeOdds(float day)
    {
        if (day == 1)
        {
            GameManager.Instance.commonUpgradeRate = 100f;
            GameManager.Instance.rareUpgradeRate = 0f;
            GameManager.Instance.epicUpgradeRate = 0f;
        }

        if (day == 2)
        {
            GameManager.Instance.commonUpgradeRate = 100f;
            GameManager.Instance.rareUpgradeRate = 0f;
            GameManager.Instance.epicUpgradeRate = 0f;
        }

        if (day == 3)
        {
            GameManager.Instance.commonUpgradeRate = 75f;
            GameManager.Instance.rareUpgradeRate = 25f;
            GameManager.Instance.epicUpgradeRate = 0f;
        }

        if (day == 4)
        {
            GameManager.Instance.commonUpgradeRate = 55f;
            GameManager.Instance.rareUpgradeRate = 30f;
            GameManager.Instance.epicUpgradeRate = 15f;
        }

        if (day == 5)
        {
            GameManager.Instance.commonUpgradeRate = 45f;
            GameManager.Instance.rareUpgradeRate = 33f;
            GameManager.Instance.epicUpgradeRate = 20f;
        }

        if (day == 6)
        {
            GameManager.Instance.commonUpgradeRate = 25f;
            GameManager.Instance.rareUpgradeRate = 40f;
            GameManager.Instance.epicUpgradeRate = 30f;
        }
    }

    public void CloseShop()
    {
        storeUI.SetActive(false);
    }

    public void OpenShop()
    {
        storeUI.SetActive(true);
        PopulateShop();
    }
}
