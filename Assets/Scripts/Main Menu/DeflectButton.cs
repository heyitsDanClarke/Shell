using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeflectButton : MonoBehaviour {

	public void ChangeLevel(){
		SceneManager.LoadScene ("Deflect");
	}
}
