using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private float timer;
    private float delay = 2.5f;

    // private float spawnInterval = 4.0f;
    // Update is called once per frame

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= delay)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                WaitSpawnDog();
                timer = 0;
            }
            
        }
    }
    void WaitSpawnDog()
    {
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
    }
    
}
