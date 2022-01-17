using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Rigidbody physics;
    public float gravity;
    public bool gameOver;
    void Start()
    {
        physics = GetComponent<Rigidbody>();     
    }


    void Update()
    {
        physics.AddForce(Physics.gravity * gravity);
    }
    public void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Over!");
    }
}
