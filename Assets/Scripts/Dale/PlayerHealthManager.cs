using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public GameObject heartPrefab;
    
    void Start()
    {

        //SetHearts(6);
    }

    public void SetHearts(float currentHealth, int maxHearts)
    {
        ClearHearts();
        float heartTracker = currentHealth;
        float numHearts = (int)(currentHealth / 2);
        numHearts = numHearts + (currentHealth % 2);
        
        for (int i = 0; i < maxHearts; i++)
        {
            
            if (heartTracker - 2 >= 0)
            {
                CreateHeart(2);
                heartTracker -= 2;
            }
            else if (heartTracker - 2 > -2)
            {
                CreateHeart(1);
                heartTracker -= 2;
            }
            else
            {
                CreateHeart(0);
            }
        }
    }

    public void CreateHeart(int heartState)
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);
        newHeart.transform.localScale = new Vector3(1,1,1);
        HealthHeart heartComponent = newHeart.GetComponent<HealthHeart>();
        heartComponent.SetHeartImage((HeartStatus)heartState);
    }

    public void ClearHearts()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
    }
}
