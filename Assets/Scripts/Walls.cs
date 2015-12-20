using UnityEngine;
using System.Collections;

public class Walls : MonoBehaviour {

	public float speed = 10;

	public GameObject core;

	void Update(){
		if(Input.GetKey("a") || Input.GetKey("left")){
			Rotate (Vector3.forward);
		}
		if(Input.GetKey("d") || Input.GetKey("right")){
			Rotate (Vector3.back);
		}

		if (Input.touchCount == 1) {
			if (Input.GetTouch (0).position.x < Screen.width / 2) {
				Rotate (Vector3.forward);
			} else if (Input.GetTouch (0).position.x > Screen.width / 2) {
				Rotate (Vector3.back);
			}
		} else if (Input.touchCount == 2) {
			if (GameMaster_Deflect.shield > 0) {
				GameMaster_Deflect.shield -= 0.5f;
			}
		}
	}

    public void Rotate(Vector3 direction){
        transform.RotateAround(core.transform.position, direction, speed * Time.deltaTime);
    }
}