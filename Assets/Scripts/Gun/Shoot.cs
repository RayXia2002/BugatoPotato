using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletLoc;

    public float shootTimer;
    private bool isShooting;
    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && !isShooting) 
        {
            StartCoroutine(ShootB());
        }
    }

    IEnumerator ShootB()
    {
        isShooting = true;
        //animator.SetBool("isClicked", true);
        //SpawnShot();
        GameObject b = Instantiate(bullet, bulletLoc.transform.position, bulletLoc.transform.rotation);
        yield return new WaitForSeconds(shootTimer);
        //animator.SetBool("isClicked", false);
        isShooting = false;
    }
}
