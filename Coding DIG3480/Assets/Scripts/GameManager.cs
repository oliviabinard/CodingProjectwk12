using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject playerPreFab;
    public GameObject enemyOnePrefab;
    public GameObject cloudPreFab;
    public GameObject coin;
    public int score;
    public int lives;
    public int cloudsMove;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    private int numOfLives;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPreFab, transform.position, Quaternion.identity);
        CreateSky();
        InvokeRepeating("CreateEnemyOne", 1.0f, 2.0f);
        InvokeRepeating("CreateCoin", 1.0f, Random.Range(5f, 20f));
        cloudsMove = 1;
        score = 0;
        lives = 3;
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        lives = lives + numOfLives;
        livesText.text = "Lives: " + lives;
    }

    void CreateEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-13, 13), 7.5f, 0), Quaternion.Euler(0, 0, 180));
    }

    void CreateSky()
    {
        for (int i = 0; i < 50; i++)
        {
            Instantiate(cloudPreFab, new Vector3(Random.Range(-13f, 13f), Random.Range(-7.5f, 7.5f), 0), Quaternion.identity);
        }
    }

        void CreateCoin()
        {
            Instantiate(coin, new Vector3(Random.Range(-13, 13), 7.5f, 0), Quaternion.identity);
        }

     public void GameOver()
        {
            CancelInvoke();
            cloudsMove = 0;
        }

        public void EarnScore(int scoreToAdd)
        {
            score = score + scoreToAdd;
            scoreText.text = "Score" + score;
        }
}
