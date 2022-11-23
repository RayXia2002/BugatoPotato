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
    public GameObject storeUI;
    public GameObject[] allUpgrades;
    public GameObject cardArea; 
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
    }

    public void PopulateShop()
    {
        ClearCards();
        Shuffle(allUpgrades);
        Vector3 spot = new Vector3(0, 0, 0);
        GameObject card1 = Instantiate(allUpgrades[0], spot, Quaternion.identity);
        GameObject card2 = Instantiate(allUpgrades[1], spot, Quaternion.identity);
        GameObject card3 = Instantiate(allUpgrades[2], spot, Quaternion.identity);
        card1.transform.SetParent(cardArea.transform);
        card1.transform.localScale = new Vector3(1,1,1);
        card2.transform.SetParent(cardArea.transform);
        card2.transform.localScale = new Vector3(1,1,1);
        card3.transform.SetParent(cardArea.transform);
        card3.transform.localScale = new Vector3(1,1,1);
    }

    public void ClearCards()
    {
        foreach(Transform t in cardArea.transform)
        {
            Destroy(t.gameObject);
        }
    }

	void Shuffle(GameObject[] a)
	{
		for (int i = a.Length-1; i > 0; i--)
		{

			int rnd = Random.Range(0,i);
			
			GameObject temp = a[i];
			
			a[i] = a[rnd];
			a[rnd] = temp;
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
