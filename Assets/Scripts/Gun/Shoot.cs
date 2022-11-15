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
    private float currentVelocity = 0;

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
        else if (meterValue < maxMeterValue && !refilling)
        {
            StartCoroutine(Refill());
        }
        float currentMeterValue = Mathf.SmoothDamp(poisonMeter.slider.value , meterValue , ref currentVelocity, 75 * Time.smoothDeltaTime);
        poisonMeter.slider.value = currentMeterValue;
    }

    IEnumerator ShootB()
    {
        isShooting = true;
        --meterValue;
        //poisonMeter.SetMeter(--meterValue);
        GameObject b = Instantiate(bullet, bulletLoc.transform.position, bulletLoc.transform.rotation);
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }

    IEnumerator Refill()
    {
        refilling = true;
        //poisonMeter.SetMeter(++meterValue);
        ++meterValue;
        yield return new WaitForSeconds(refillTimer);
        refilling = false;
    }
}