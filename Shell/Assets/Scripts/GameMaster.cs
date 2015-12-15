using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameMaster : MonoBehaviour {

	public static float health = 10;
	public static float score = 0;
	float highScore;

	Text healthDisplay;
	Text scoreDisplay;
	Text highscoreDisplay;


	void Start () {
		Advertisement.Initialize ("1020810",true);
		//		StartCoroutine (ShowAdWhenReady ());

		healthDisplay = GameObject.Find ("Health").GetComponent<Text>();
		scoreDisplay = GameObject.Find ("Score").GetComponent<Text>();
		highscoreDisplay = GameObject.Find ("High Score").GetComponent<Text>();

		highScore = PlayerPrefs.GetInt("HighScore",0);
		highscoreDisplay.text = highScore.ToString();

	}

	void Update () {
		if (health > 0)
			healthDisplay.text = health.ToString ();
		else {
			healthDisplay.text = "Game Over";
			if (Advertisement.IsReady ()) {
				Advertisement.Show ();	
			}
		}
		scoreDisplay.text = score.ToString();
	}

	IEnumerator ShowAdWhenReady()
	{
		while (!Advertisement.IsReady())
			yield return null;

		Advertisement.Show ();
	}
}
