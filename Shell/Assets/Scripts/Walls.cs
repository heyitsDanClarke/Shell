using UnityEngine;
using System.Collections;

public class Walls : MonoBehaviour {

	public float speed = 10;

	public GameObject wall_l;
	public GameObject wall_r;

	void Update(){
		if(Input.GetKey("a") || Input.GetKey("left")){
			Rotate (Vector3.forward);
		}
		if(Input.GetKey("d") || Input.GetKey("right")){
			Rotate (Vector3.back);
		}

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x < Screen.width / 2)
            {
                Rotate(Vector3.forward);
            }
            else if (Input.GetTouch(0).position.x > Screen.width / 2)
            {
                Rotate(Vector3.back);
            }
        }
	}

    public void Rotate(Vector3 direction){
        wall_l.transform.RotateAround (Vector3.zero, direction, speed * Time.deltaTime);
        wall_r.transform.RotateAround (Vector3.zero, direction, speed * Time.deltaTime);
    }
}