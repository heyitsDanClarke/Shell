using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	GameObject player;
	public GameObject pauseMenu;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	public void Pause(){
		Time.timeScale = 0;
		player.SetActive (false);
		pauseMenu.SetActive (true);
	}
}
