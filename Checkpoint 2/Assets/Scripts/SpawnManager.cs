using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spherePrefabs;
    private float xBoundaryLeft = -65.0f;
    private float xBoundaryRight = 159.0f;
    private float zBoundaryTop = 60.0f;
    private float zBoundaryBottom = -56.0f;
    private const float yRange = 80.0f;
    private int amound;
    private float startDelay = 0.5f;
    private float repeatTime = 2.5f;
    private GameController gameController;
    void Start()
    {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
        InvokeRepeating("SpawnSphere", startDelay, repeatTime);

    }

    // Update is called once per frame
    void Update()
    {
        //SpawnSphere();
    }
    void SpawnSphere()
    {
        int index = Random.Range(0, spherePrefabs.Length);
        Vector3 randomPos = new Vector3(Random.Range(xBoundaryLeft, xBoundaryRight)
            , yRange, Random.Range(zBoundaryBottom, zBoundaryTop));
        if (!gameController.gameOver)
        {
            Instantiate(spherePrefabs[index], randomPos, spherePrefabs[index].transform.rotation);
        }
        else
            gameController.GameOver();
        
        //StartCoroutine(BallProduction());
    }
    IEnumerator BallProduction()
    {
        yield return new WaitForSeconds(2f);

    }
}
