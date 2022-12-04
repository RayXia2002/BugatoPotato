using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowMeterWarning : MonoBehaviour
{
    private GameObject player;          // dale prefab
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 loc = player.transform.position;
        loc.y = loc.y + 0.34f;
        this.transform.position = loc;
    }
    
    public void Activate() {
        gameObject.SetActive(true);
    }
    public void Deactivate() {
        gameObject.SetActive(false);
    }
}