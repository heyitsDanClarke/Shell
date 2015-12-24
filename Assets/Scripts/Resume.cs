using UnityEngine;
using System.Collections;

public class Resume : MonoBehaviour {

	public GameObject player;

	public void ResumeGame(){
		Time.timeScale = 1;
		player.SetActive (true);
		this.transform.parent.gameObject.SetActive (false);
	}
}
