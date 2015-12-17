using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class No : MonoBehaviour {

	public void Quit(){
		SceneManager.LoadScene ("MainMenu");
	}
}
