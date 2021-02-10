using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static int score;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void AddScore()
    {
        score++;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        Debug.Log("Game Over!");
        gameOverScreen.SetActive(true);
    }
}
