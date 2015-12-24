using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Walls : MonoBehaviour {

	public float speed = 10;

	public GameObject core;

	bool deflect = false;

	void Start(){
		if (SceneManager.GetActiveScene().name == "Deflect")
			deflect = true;
	}

	void Update(){
		if(Input.GetKey("a") || Input.GetKey("left")){
			Rotate (Vector3.forward);
		}
		if(Input.GetKey("d") || Input.GetKey("right")){
			Rotate (Vector3.back);
		}

		if (Input.touchCount < 2) {
			if(deflect)
				transform.GetChild (2).gameObject.SetActive (false);
			if (Input.touchCount == 1) {
				if (Input.GetTouch (0).position.x < Screen.width / 2) {
					Rotate (Vector3.forward);
				} else if (Input.GetTouch (0).position.x > Screen.width / 2) {
					Rotate (Vector3.back);
				}
			}
		} else if (Input.touchCount == 2 && deflect) {
			if (GameMaster_Deflect.shield > 0) {
				GameMaster_Deflect.shield -= 0.5f;
				transform.GetChild (2).gameObject.SetActive (true);
			}
			else
				transform.GetChild (2).gameObject.SetActive (false);
		}
	}

    public void Rotate(Vector3 direction){
        transform.RotateAround(core.transform.position, direction, speed * Time.deltaTime);
    }
}