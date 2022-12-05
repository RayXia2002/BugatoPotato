using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletLoc;
    public float shootTimer = 0.3f;
    private bool isShooting;
    public float maxMeterValue;
    public float refillTimer = 0.5f;
    public float meterValue;
    private bool refilling;
    private float currentVelocity = 0;
    public bool canFire = true;
    private bool warningActive = false; // true if low meter warning is active
    public PoisonMeter poisonMeter;
    private GameObject player;          // dale prefab
    public GameObject warning;         // low meter warning obj
    private LowMeterWarning warnScript;

    // Start is called before the first frame update
    void Start()
    {
        poisonMeter.SetMaxMeter(maxMeterValue);
        isShooting = false;
        refilling = false;
        meterValue = maxMeterValue;
        player = GameObject.FindWithTag("Player");
        warnScript = warning.GetComponent<LowMeterWarning>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && !isShooting && meterValue > 0 && canFire) 
        {
            GetComponent<AudioSource>().Play();
            if (!GameManager.Instance.splitShot)
            {
                StartCoroutine(ShootB());
            }
            else
            {
                StartCoroutine(ShootSplit());
            }
        }
        else if (meterValue < maxMeterValue && !refilling && !Input.GetButton("Fire1"))
        {
            StartCoroutine(Refill());
        }
        float currentMeterValue = Mathf.SmoothDamp(poisonMeter.slider.value , meterValue , ref currentVelocity, 75 * Time.smoothDeltaTime);
        poisonMeter.slider.value = currentMeterValue;
        
        // low meter warning
        if (!warningActive && (currentMeterValue <= 3)) {
            warningActive = true;
            warnScript.Activate();
        }
        if (warningActive && currentMeterValue > 3) {
            warningActive = false;
            warnScript.Deactivate();
        }
    }
    IEnumerator ShootB()
    {
        isShooting = true;
        --meterValue;
        //poisonMeter.SetMeter(--meterValue);
        GameObject b = Instantiate(bullet, bulletLoc.transform.position, bulletLoc.transform.rotation);
        GameObject c = Instantiate(bullet, bulletLoc.transform.position, bulletLoc.transform.rotation);
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }
    IEnumerator ShootSplit()
    {
        isShooting = true;
        --meterValue;
        //poisonMeter.SetMeter(--meterValue);
        GameObject b = Instantiate(bullet, bulletLoc.transform.position, bulletLoc.transform.rotation * new Quaternion(0,0,0.25f,1));
        GameObject c = Instantiate(bullet, bulletLoc.transform.position, bulletLoc.transform.rotation * new Quaternion(0,0,-0.25f,1));
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
    public void UpgradeFireRate(float val) {
        shootTimer -= val;
    }
    public void UpgradeRefillTimer(float val) {
        refillTimer -= val;
    }
}
