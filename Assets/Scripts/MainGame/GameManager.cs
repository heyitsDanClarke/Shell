using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public int health = 10;
    public int score = 0;

    int highScore;

    Text healthDisplay;
    Text scoreDisplay;
    Text highscoreDisplay;

    GameObject player;
    public GameObject replayMenu;

    bool _gameOver = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    void Start () {
        PlayerPrefs.SetInt("First Time", 1);

        Time.timeScale = 1;

        scoreDisplay = GameObject.Find("Score").GetComponent<Text>();
        highscoreDisplay = GameObject.Find("High Score").GetComponent<Text>();

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highscoreDisplay.text = highScore.ToString();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (health <= 0 && !_gameOver)
        {
            Time.timeScale = 0;
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Bullet"))
                Destroy(go);
            GameObject.Find("Menu").GetComponent<Button>().interactable = false;
            GameObject.Find("Health").GetComponent<HealthBar>().ResetColor();
            player.SetActive(false);
            replayMenu.SetActive(true);
            _gameOver = true;
        }
        scoreDisplay.text = score.ToString();
        if (highScore < score)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        highscoreDisplay.text = highScore.ToString();
    }
}
