using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Yes : MonoBehaviour {

	public void Replay(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
}
