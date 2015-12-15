using UnityEngine;
using System.Collections;

public class Walls : MonoBehaviour {

	public float speed = 10;

	public GameObject wall_l;
	public GameObject wall_r;

	public bool touch_r = false;
	public bool touch_l = false;

	void Update(){
		if(Input.GetKey("a") || Input.GetKey("left") || touch_l){
			RotateLeft ();
		}
		if(Input.GetKey("d") || Input.GetKey("right") || touch_r){
			RotateRight ();
		}
	}

	public void RotateLeft(){
		wall_l.transform.RotateAround (Vector3.zero, Vector3.forward, speed * Time.deltaTime);
		wall_r.transform.RotateAround (Vector3.zero, Vector3.forward, speed * Time.deltaTime);
	}

	public void RotateRight(){
		wall_l.transform.RotateAround (Vector3.zero, Vector3.back, speed * Time.deltaTime);
		wall_r.transform.RotateAround (Vector3.zero, Vector3.back, speed * Time.deltaTime);
	}

	public void setTouchL(){
		touch_l = !touch_l;
	}

	public void setTouchR(){
		touch_r = !touch_r;
	}
}