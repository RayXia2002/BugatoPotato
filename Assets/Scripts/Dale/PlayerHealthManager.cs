using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public GameObject heartPrefab;
    
    void Start()
    {

        UpdateHearts(6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHearts(int currentHealth)
    {
        ClearHearts();
        int heartTracker = currentHealth;
        int numHearts = (int)(currentHealth / 2);
        numHearts = numHearts + (currentHealth % 2);
        for (int i = 0; i < numHearts; i++)
        {
            Debug.Log(heartTracker);
            if (heartTracker - 2 >= 0)
            {
                CreateHeart(2);
                heartTracker -= 2;
            }
            else if (heartTracker - 2 >= -2)
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
