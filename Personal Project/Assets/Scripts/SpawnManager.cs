using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemyPrefabs;
    public GameObject powerupPrefab;
    public int powerupCount;
    private float xRange = 18.0f;
    private float zRange = 18.0f;
    private float startDelay = 2;
    private float repeatDelay = 2;
    public bool hasPowerup = false;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, repeatDelay);
        InvokeRepeating("SpawnPowerup", startDelay, repeatDelay + 5);
    }


    void Update()
    {
        // SpawnPowerup();
        if (powerupCount == 0)
        {
            SpawnPowerup();
        }

    }

    void SpawnEnemy()
    {
        Vector3 randomPos = new Vector3(Random.Range(xRange, -xRange), 0.6f, Random.Range(zRange, -zRange));
        int index = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[index].gameObject, randomPos, enemyPrefabs[index].transform.rotation);
    }
    void SpawnPowerup()
    {
        Vector3 randomPos = new Vector3(Random.Range(xRange, -xRange), 0.6f, Random.Range(zRange, -zRange));
        Instantiate(powerupPrefab.gameObject, randomPos, powerupPrefab.transform.rotation);
        // StartCoroutine(PowerupCoolDown());
        powerupCount++;
        hasPowerup = true;
    }
    /*
    IEnumerator PowerupCoolDown()
    {
        yield return new WaitForSeconds(5);
        hasPowerup = false;
    }
    */
}
