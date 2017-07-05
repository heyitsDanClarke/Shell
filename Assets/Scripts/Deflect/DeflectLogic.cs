using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeflectLogic: MonoBehaviour {

    public static DeflectLogic Instance;

	public int health = 10;
	public int score = 0;
	public float shield = 100;
	int highScore;

	bool _gameOver = false;

	Text healthDisplay;
	Text scoreDisplay;
	Text highscoreDisplay;

	GameObject player;
	public GameObject replayMenu;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

	void Start () {
		PlayerPrefs.SetInt ("First Time", 1);

		shield = 100;
		health = 10;
		score = 0;
		Time.timeScale = 1;

		scoreDisplay = GameObject.Find ("Score").GetComponent<Text>();
		highscoreDisplay = GameObject.Find ("High Score").GetComponent<Text>();

		highScore = PlayerPrefs.GetInt("HighScore",0);
		highscoreDisplay.text = highScore.ToString();

		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void FixedUpdate () {
		if(health <= 0 && !_gameOver)
        {
			Time.timeScale = 0;
			foreach (GameObject go in GameObject.FindGameObjectsWithTag("Bullet"))
				Destroy (go);
			GameObject.Find ("Menu").GetComponent<Button>().interactable = false;
			GameObject.Find ("Health").GetComponent<HealthBar> ().ResetColor ();
			GameObject.Find ("ShieldBar").GetComponent<ShieldBar> ().ResetColor ();
			player.SetActive (false);
			replayMenu.SetActive (true);
			_gameOver = true;
		}
		scoreDisplay.text = score.ToString();
		if (highScore < score) {
			highScore = score;
			PlayerPrefs.SetInt("HighScore", highScore);
		}
		highscoreDisplay.text = highScore.ToString();
	}
}