using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class Initialize : MonoBehaviour {

	public GameObject tutorialText;

	void Start () {
		Time.timeScale = 1;

		if (PlayerPrefs.GetInt ("First Time", 0) == 0) {
			tutorialText.SetActive (true);
		}

		#if UNITY_ANDROID
		Advertisement.Initialize ("1020810",true);
		#elif UNITY_IPHONE
		Advertisement.Initialize("1020811",true);
		#endif
	}
}