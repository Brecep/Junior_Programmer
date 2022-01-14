using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targests;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject tittleScreen;


    private float spawnRate = 1.0f;
    public int score;
    public bool isGameActive;
    void Start()
    {

    }

    void Update()
    {

    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)//true oldukça spawn
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targests.Count);
            Instantiate(targests[index]);//addforce ve tork eklendiði için rotation ile positiona gerek kalmadý
        }
    }
    public void UpdateScore(int scoreAdd)
    {
        score += scoreAdd;
        scoreText.text = "Score : " + score;
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        tittleScreen.gameObject.SetActive(false);

    }
}
