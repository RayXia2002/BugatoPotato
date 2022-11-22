using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    // possible bug spawn gameobjects
    public GameObject beetleSpawn;
    public GameObject flySpawn;
    public GameObject caterSpawn;
    public GameObject hornetSpawn;

    // values for spawning rate
    public float spawnRate = 3f;
    public float spawnCaterRate = 0.5f;
    public float spawnBeetleRate = 3f;
    public float spawnFlyRate = 3f;
    public float spawnHornetRate = 3f;
    private float lastSpawn = 0f;
    private float lastSpawnCater = 0f;
    private float lastSpawnBeetle = 0f;
    private float lastSpawnFly = 0f;
    private float lastSpawnHornet = 0f;
    public bool spawn = false;
    public bool pause = false;

    // min max for spawning
    private const float X_MIN = -4.7f;
    private const float X_MAX = 4.7f;
    private const float BEET_Y_VAL = -1.6f;
    private const float CAT_Y_VAL = -1.67f;

    // Update is called once per frame
    void Update()
    {        
        if ((Time.time - lastSpawnCater >= spawnRate * spawnCaterRate) && spawn && !pause && GameManager.Instance.day >= 1) 
        {
            spawnCater();
            lastSpawnCater = Time.time;
        }

        if ((Time.time - lastSpawnBeetle >= spawnRate * spawnBeetleRate) && spawn && !pause && GameManager.Instance.day >= 2) 
        {
            spawnBeetle();
            lastSpawnBeetle = Time.time;
        }

        if ((Time.time - lastSpawnFly >= spawnRate * spawnFlyRate) && spawn && !pause && GameManager.Instance.day >= 3) 
        {
            spawnFly();
            lastSpawnFly = Time.time;
        }

        if ((Time.time - lastSpawnHornet >= spawnRate * spawnHornetRate) && spawn && !pause && GameManager.Instance.day >= 4) 
        {
            spawnHornet();
            lastSpawnHornet = Time.time;
        }
        
    }


    // spawns a caterpillar from random direction (left:0 or right:1)
    private void spawnCater() {
        // get random direction
        int direction = Random.Range(0, 2);

        // set xval depending on direction
        float xval = direction == 1 ? X_MIN : X_MAX;

        // create cater
        Vector3 pos = new Vector3(xval, CAT_Y_VAL, 0f);
        GameObject cater = Instantiate(caterSpawn, pos, Quaternion.identity);

        if (direction == 1) {
            // face the right if direction is right
            Vector3 origScale = cater.transform.localScale;
            origScale.x *= -1;
            cater.transform.localScale = origScale;
            // change walking direction
            cater.GetComponent<CaterBehave>().speed = -1* cater.GetComponent<CaterBehave>().speed;
        }
    }

    // spawns a beetle from random direction (left:0 or right:1)
    private void spawnBeetle() {
        // get random direction
        int direction = Random.Range(0, 2);

        // set xval depending on direction
        float xval = direction == 1 ? X_MIN : X_MAX;

        // create beetle
        Vector3 pos = new Vector3(xval, BEET_Y_VAL, 0f);
        GameObject beetle = Instantiate(beetleSpawn, pos, Quaternion.identity);

        if (direction == 0) {
            // face the left if direction is left
            Vector3 origScale = beetle.transform.localScale;
            origScale.x *= -1;
            beetle.transform.localScale = origScale;
            // change walking direction
            beetle.GetComponent<BeetleBehave>().speed = -1 * beetle.GetComponent<BeetleBehave>().speed;
        }
    }

    // spawns a flying beetle from random direction, anywhere between y min/max and x min/max
    private void spawnFly() {
        
        GameObject plant = GameObject.FindGameObjectWithTag("stem");
        float plantHeight = plant.GetComponent<SpriteRenderer>().bounds.size.y;
        float minHeight = plant.transform.position.y + 0.1f - plantHeight / 2;
        float maxHeight = plant.transform.position.y - 0.1f + plantHeight / 2;
        // get random direction
        int direction = Random.Range(0, 2);
        float height = (Random.Range(minHeight, maxHeight));
        // set xval depending on direction
        float xval = direction == 1 ? X_MIN : X_MAX;

        // create flying beetle
        //Vector3 pos = new Vector3(-3.6f, -0.2f, 0f);
        Vector3 pos = new Vector3(xval, maxHeight, -1f);
        GameObject flyBeetle = Instantiate(flySpawn, pos, Quaternion.identity);

        if (direction == 0) {
            // face the left if direction is left
            Vector3 origScale = flyBeetle.transform.localScale;
            origScale.x *= -1;
            flyBeetle.transform.localScale = origScale;
            // change walking direction
            flyBeetle.GetComponent<FlyBehave>().speed = -1 * flyBeetle.GetComponent<FlyBehave>().speed;
        }
    }

    private void spawnHornet() {
        // get random direction
        int direction = Random.Range(0, 2);
        float height = Random.Range(-1f, 2.5f);
        // set xval depending on direction
        float xval = direction == 1 ? X_MIN : X_MAX;

        // create hornet
        Vector3 pos = new Vector3(xval, height, 0f);
        GameObject hornet = Instantiate(hornetSpawn, pos, Quaternion.identity);

        if (direction == 0) {
            // face the left if direction is left
            Vector3 origScale = hornet.transform.localScale;
            origScale.x *= -1;
            hornet.transform.localScale = origScale;
        }
    }

    public void setPause(bool p)
    {
        pause = p;
        lastSpawn = Time.time;
    }

}
