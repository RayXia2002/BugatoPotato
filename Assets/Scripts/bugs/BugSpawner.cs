using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    // possible bug spawn gameobjects
    public GameObject beetleSpawn;
    public GameObject flySpawn;
    public GameObject caterSpawn;

    // values for spawning rate
    private float spawnRate = 5f;
    private float lastSpawn = 0f;

    // min max for spawning
    private const float X_MIN = -3.6f;
    private const float X_MAX = 3.6f;
    private const float BEET_Y_VAL = -1.6f;
    private const float CAT_Y_VAL = -1.67f;


    // Update is called once per frame
    void Update()
    {
        if ((Time.time - lastSpawn >= spawnRate)) {
            spawnRand();
            lastSpawn = Time.time;
        }
    }

    private void spawnRand()
    {
        // spawn one of three different bugs chosen randomly
        int bugNum = Random.Range(0, 3);
        if (bugNum == 0){
            // spawn beetle
            spawnBeetle();
        } else if (bugNum == 1) {
            // spawn caterpillar
            spawnCater();
        } else {
            // spawn flying beetle
            spawnFly();
        }
    }


    // spawns a caterpillar from random direction (left or right)
    private void spawnCater() {
        // get random direction
        int direction = Random.Range(0, 2);

        // set xval depending on direction
        float xval = direction == 1 ? X_MIN : X_MAX;

        // create cater
        Vector3 pos = new Vector3(xval, CAT_Y_VAL, 0f);
        GameObject cater = Instantiate(caterSpawn, pos, Quaternion.identity);

        if (direction == 0) {
            // face the left if direction is left
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * 180f);
        }
    }

    // spawns a beetle from random direction (left or right)
    private void spawnBeetle() {
        // get random direction
        int direction = Random.Range(0, 2);

        // set xval depending on direction
        float xval = direction == 1 ? X_MIN : X_MAX;

        // create fly beetle
        Vector3 pos = new Vector3(xval, BEET_Y_VAL, 0f);
        GameObject beetle = Instantiate(beetleSpawn, pos, Quaternion.identity);

        if (direction == 0) {
            // face the left if direction is left
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * 180f);
        }
    }

    // spawns a flying beetle from random direction, anywhere between y min/max and x min/max
    private void spawnFly() {
        Vector3 pos = new Vector3(-3.6f, -0.2f, 0f);
        GameObject flyBeetle = Instantiate(flySpawn, pos, Quaternion.identity);
    }
}
