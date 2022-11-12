using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletLoc;

    public float shootTimer;
    private bool isShooting;

    public float maxMeterValue;
    public float refillTimer;
    private float meterValue;
    private bool refilling;

    public PoisonMeter poisonMeter;
    // Start is called before the first frame update
    void Start()
    {
        poisonMeter.SetMaxMeter(maxMeterValue);
        isShooting = false;
        refilling = false;
        meterValue = maxMeterValue;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && !isShooting && meterValue > 0) 
        {
            StartCoroutine(ShootB());
        }
        else if (meterValue < maxMeterValue && !refilling) //&& !Input.GetButton("Fire1")
        {
            StartCoroutine(Refill());
        }
    }

    IEnumerator ShootB()
    {
        isShooting = true;
        poisonMeter.SetMeter(--meterValue);
        GameObject b = Instantiate(bullet, bulletLoc.transform.position, bulletLoc.transform.rotation);
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }

    IEnumerator Refill()
    {
        refilling = true;
        poisonMeter.SetMeter(++meterValue);
        yield return new WaitForSeconds(refillTimer);
        refilling = false;
    }
}