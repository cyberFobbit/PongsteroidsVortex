using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int score;
    public static GameManager instance;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;
    public GameObject blackHole;

    private void Awake()
    {
        //Initiate singelton
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying...");
            Destroy(this);
        }

        score = 0;
        gameOverScreen.SetActive(false);
    }

    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        //Time.timeScale = 0;
        Debug.Log("Game Over!");
        gameOverScreen.SetActive(true);

        Tools.instance.Tween(blackHole.transform, "localScale", Vector3.one * 56, 1, true);
        StartCoroutine(ClearGame(0.6f));
    }

    public IEnumerator ClearGame(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        GameObject.FindGameObjectWithTag("GameObjects").SetActive(false);
        foreach (Asteroid asteroid in FindObjectsOfType<Asteroid>()) Destroy(asteroid.gameObject);
    }

}
