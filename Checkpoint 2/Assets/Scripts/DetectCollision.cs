using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public GameController gameController;
    private void Start()
    {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!other.gameObject.CompareTag("Box"))
        {
            gameController.gameOver = true;
        }
        else
            gameController.GameOver();
    }

}
