using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private float spawnRangeX = 20;
    private float spawnPosZ = 20;

    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    private float spawnRandomZ;
    private int rotationDegreeLeft;
    private int rotationDegreeRight;
    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);//2 second wait
            InvokeRepeating("SpawnRandomLeftAnimal", startDelay, spawnInterval);//bonus
            InvokeRepeating("SpawnRandomRightAnimal", startDelay, spawnInterval);//bonus
        }
    }
    void SpawnRandomAnimal()
    {

        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0,180,0));
    }

    //bonus
    private float lowerSpawnZ = 0;
    private float topSpawnZ = 12.5f;
    private float fixedSpawnX = 30;
    void SpawnRandomLeftAnimal()//bonus
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(-fixedSpawnX, 0, Random.Range(lowerSpawnZ, topSpawnZ));
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, 90, 0));
    }
    void SpawnRandomRightAnimal()//bonus
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(fixedSpawnX, 0, Random.Range(lowerSpawnZ, topSpawnZ));
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, 270, 0));
    }
}
