using UnityEngine;

public class Initialize : MonoBehaviour
{
	public GameObject tutorialText;

	void Start ()
    {
		Time.timeScale = 1;

		if (PlayerPrefs.GetInt ("First Time", 0) == 0) {
			tutorialText.SetActive (true);
		}
	}
}