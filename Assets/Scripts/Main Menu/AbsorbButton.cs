using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AbsorbButton : MonoBehaviour {

	public void ChangeLevel(){
		SceneManager.LoadScene ("Absorb");
	}
}
