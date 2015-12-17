using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public static float timer = 30;

	void Update(){
		if (timer > 0) {
			timer -= Time.deltaTime;
			this.GetComponent<Text> ().text = timer.ToString ("0");
		}
	}
}
