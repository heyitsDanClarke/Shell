using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	Color turquoise = new Color (64, 224, 208);
	Color green = new Color (153, 201, 83);
	Color grey = new Color (131, 144, 152);
	Color orange = new Color (245, 109, 68);
	Color blue = new Color (86, 132, 227);
	Color yellow = new Color (246, 215, 81);
	Color pink = new Color (230, 93, 113);
	Color purple = new Color (143, 67, 201);

	Color[] colors;

	int currentColor = 0;
	int newColor;

	bool colorChanged = true;

	void Start(){
		colors = new Color[8];
		colors [0] = turquoise;
		colors [1] = green;
		colors [2] = grey;
		colors [3] = orange;
		colors [4] = blue;
		colors [5] = yellow;
		colors [6] = pink;
		colors [7] = purple;

		Camera.main.backgroundColor = colors[2];
		Debug.Log (Camera.main.backgroundColor);
	}

	void Update(){
		if (GameMaster_Deflect.score % 1000 == 0 && GameMaster_Deflect.score != 0 && colorChanged) {
			colorChanged = false;
			newColor = Random.Range (0, 8);
		}
		if (!colorChanged) {
			//Camera.main.backgroundColor = Color.Lerp (colors [currentColor], colors [newColor], Time.deltaTime);
			Camera.main.backgroundColor = colors[newColor];
			Debug.Log (Camera.main.backgroundColor);
			if (Camera.main.backgroundColor == colors [newColor]) {
				colorChanged = true;
			}
		}
//		if (GameMaster_Deflect.score % 1000 == 0 && GameMaster_Deflect.score != 0 && colorChanged) {
//			colorChanged = false;
//			StartCoroutine (ChangeColour ());
//		}
	}

	IEnumerator ChangeColour(){
		int newColor = Random.Range (0, 8);
		while (Camera.main.backgroundColor != colors [newColor]) {
			Camera.main.backgroundColor = Color.Lerp (colors [currentColor], colors [newColor], Time.deltaTime);
			Debug.Log (Camera.main.backgroundColor);
			yield return null;
		}
		currentColor = newColor;
		colorChanged = true;
	}
}
