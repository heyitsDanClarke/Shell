using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour {
	Color32 turquoise = new Color32 (64, 224, 208,255);
	Color32 blue = new Color32 (121, 123, 212,255);
	Color32 fuschia = new Color32 (181, 64, 224,255);
	Color32 pink = new Color32 (224, 64, 132,255);
	Color32 red = new Color32 (224, 64, 64,255);
	Color32 orange = new Color32 (245, 83, 57,255);
	Color32 yellow = new Color32 (224, 218, 64,255);
	Color32 green = new Color32(143,224,64,255);

	Color32[] colors;

	int currentColor = 0;
	int newColor;

	int currentScore = 0;
	int currentLevel = 1;

	bool deflect;
	bool absorb;

	void Start(){
		colors = new Color32[8];
		colors [0] = turquoise;
		colors [1] = blue;
		colors [2] = fuschia;
		colors [3] = pink;
		colors [4] = red;
		colors [5] = orange;
		colors [6] = yellow;
		colors [7] = green;

		if (SceneManager.GetActiveScene().name == "Deflect")
			deflect = true;
		else if (SceneManager.GetActiveScene().name == "Absorb")
			absorb = true;
	}

	void Update(){
		if (deflect) {
			if (GameMaster_Deflect.score % 1000 == 0 && GameMaster_Deflect.score > currentScore) {
				currentScore = GameMaster_Deflect.score;
				StartCoroutine (ChangeColour ());
			}
		} else if (absorb) {
			if (GameMaster_Absorb.level > currentLevel) {
				currentLevel += 1;
				StartCoroutine (ChangeColour ());
			}
		}
	}

	IEnumerator ChangeColour(){
		if (currentColor < colors.Length - 1)
			newColor = currentColor + 1;
		else
			newColor = 0;
		float t = 0;
		while(Camera.main.backgroundColor != colors[newColor]){
			t += Time.deltaTime;
			Camera.main.backgroundColor = Color32.Lerp (colors[currentColor], colors[newColor], t);
			yield return null;
		}
		currentColor = newColor;
	}
}
