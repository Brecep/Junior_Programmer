using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1f;
    private float lowerInterval = 3f;
    private float topInterval = 5f;
    private float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRandomBall", startDelay);
        
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {
        // Generate random ball index and random spawn position
        int randomBallPrefabsIndex = Random.Range(0, ballPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[randomBallPrefabsIndex], spawnPos, ballPrefabs[randomBallPrefabsIndex].transform.rotation);

        spawnInterval = Random.Range(lowerInterval, topInterval);
        Invoke("SpawnRandomBall", spawnInterval);

        

        //Debug.Log(spawnInterval + " waited and came");
        
        
    }
    
    

}
