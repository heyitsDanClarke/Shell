using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour {
	Color32 turquoise = new Color32 (64, 224, 208,255);
	Color32 green = new Color32 (153, 201, 83,255);
	Color32 grey = new Color32 (131, 144, 152,255);
	Color32 orange = new Color32 (245, 109, 68,255);
	Color32 blue = new Color32 (86, 132, 227,255);
	Color32 yellow = new Color32 (246, 215, 81,255);
	Color32 pink = new Color32 (230, 93, 113,255);
	Color32 purple = new Color32 (143, 67, 201,255);

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
		colors [1] = green;
		colors [2] = grey;
		colors [3] = orange;
		colors [4] = blue;
		colors [5] = yellow;
		colors [6] = pink;
		colors [7] = purple;

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
