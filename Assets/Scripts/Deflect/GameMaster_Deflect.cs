using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster_Deflect: MonoBehaviour {

	public static int health = 10;
	public static int score = 0;
	public static float shield = 100;
	int highScore;

	Text healthDisplay;
	Text scoreDisplay;
	Text highscoreDisplay;
	Text shieldDisplay;

	GameObject player;
	public GameObject replayMenu;

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

	void Update () {
		if(health <= 0)
        {
			Time.timeScale = 0;
			foreach (GameObject go in GameObject.FindGameObjectsWithTag("Bullet"))
				Destroy (go);
			foreach (GameObject go in GameObject.FindGameObjectsWithTag("Target"))
				Destroy (go);
			GameObject.Find ("Menu").GetComponent<Button>().interactable = false;
			player.SetActive (false);
			replayMenu.SetActive (true);
		}
		scoreDisplay.text = score.ToString();
		if (highScore < score) {
			highScore = score;
			PlayerPrefs.SetInt("HighScore", highScore);
		}
		highscoreDisplay.text = highScore.ToString();
	}
}