using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text highScoreText;
    public int score;
    [SerializeField] int highScore;

    public bool GoBack = false;
    public bool GoPlanet = false;
    public GameObject PlanetCheckpoint;
    public GameObject MothershipCheckpoint;


    void Start()
    {
        LoadHighScore();
    }

    void Update()
    {
        if(score >= 500)
        {
            GoPlanet = true;
        }
        else
        {
            GoPlanet = false;
        }
    }


    void OnEnable()
    {
        EventManager.onStartGame += ResetScore;
        EventManager.onStartGame += LoadHighScore;
        EventManager.onPlayerDeath += CheckNewHighScore;
        EventManager.onScorePoints += AddScore;
    }


    void OnDisable()
    {
        EventManager.onStartGame -= ResetScore;
        EventManager.onStartGame -= LoadHighScore;
        EventManager.onPlayerDeath -= CheckNewHighScore;
        EventManager.onScorePoints -= AddScore;
    }


    void ResetScore()
    {
        score = 0;
        DisplayScore();
    }



    void AddScore(int amt)
    {
        score += amt;
        DisplayScore();
    }


    void DisplayScore()
    {
        scoreText.text = score.ToString();
    }

    void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        DisplayHighScore();
    }


    void CheckNewHighScore()
    {
        if(score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            DisplayHighScore();
        }
    }



    void DisplayHighScore()
    {
        highScoreText.text = highScore.ToString();
    }
}
