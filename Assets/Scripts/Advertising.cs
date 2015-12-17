using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class Advertising : MonoBehaviour {

	void Start () {
		Time.timeScale = 1;
		#if UNITY_ANDROID
		Advertisement.Initialize ("1020810",true);
		#elif UNITY_IPHONE
		Advertisement.Initialize("1020811",true);
		#endif
	}
}