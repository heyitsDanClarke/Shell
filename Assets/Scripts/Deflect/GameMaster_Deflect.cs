﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameMaster_Deflect: MonoBehaviour {

	public static int health = 10;
	public static int score = 0;
	int highScore;

	Text healthDisplay;
	Text scoreDisplay;
	Text highscoreDisplay;

	GameObject player;
	GameObject replayMenu;

	bool adTime = true;

	void Start () {
		health = 10;
		adTime = true;
		Time.timeScale = 1;

		healthDisplay = GameObject.Find ("Health").GetComponent<Text>();
		scoreDisplay = GameObject.Find ("Score").GetComponent<Text>();
		highscoreDisplay = GameObject.Find ("High Score").GetComponent<Text>();

		highScore = PlayerPrefs.GetInt("HighScore",0);
		highscoreDisplay.text = highScore.ToString();

		player = GameObject.FindGameObjectWithTag ("Player");
		replayMenu = GameObject.FindGameObjectWithTag ("ReplayMenu");
		replayMenu.SetActive (false);
	}

	void Update () {
		if (health > 0)
			healthDisplay.text = health.ToString ();
		else {
			healthDisplay.text = "Game Over";
			if (Advertisement.IsReady () && adTime == true) {
				Advertisement.Show ();	
				adTime = false;
			}
			Time.timeScale = 0;
			foreach (GameObject go in GameObject.FindGameObjectsWithTag("Bullet"))
				Destroy (go);
			foreach (GameObject go in GameObject.FindGameObjectsWithTag("Target"))
				Destroy (go);
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