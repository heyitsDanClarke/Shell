using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Walls : MonoBehaviour {

	public float maxSpeed = 200;
	public float speed = 100;
	public float acceleration = 10;
	float startSpeed;

	public GameObject core;

	bool deflect = false;

	bool recovering = false;

	void Start(){
		if (SceneManager.GetActiveScene().name == "Deflect")
			deflect = true;
		startSpeed = speed;
	}

	void FixedUpdate(){
		if(Input.GetKey("a") || Input.GetKey("left")){
			Rotate (Vector3.forward);
			speed += acceleration;
			speed = Mathf.Min (maxSpeed, speed);
		}
		if(Input.GetKey("d") || Input.GetKey("right")){
			Rotate (Vector3.back);
			speed += acceleration;
			speed = Mathf.Min (maxSpeed, speed);
		}

		if (Input.touchCount < 2) {
			if (deflect) {
				transform.GetChild (2).gameObject.SetActive (false);
                if (GameMaster_Deflect.shield < 100 && !recovering)
                    GameMaster_Deflect.shield += Time.deltaTime * 2; //adjust to change shield recovery
			}
			if (Input.touchCount == 0) {
				speed = startSpeed; //reset speed if not rotating
			} else if (Input.touchCount == 1 && !EventSystem.current.IsPointerOverGameObject (Input.GetTouch (0).fingerId)) {
				if (Input.GetTouch (0).position.x < Screen.width / 2) {
					Rotate (Vector3.forward);
					speed += acceleration;
					speed = Mathf.Min (maxSpeed, speed);
				} else if (Input.GetTouch (0).position.x > Screen.width / 2) {
					Rotate (Vector3.back);
					speed += acceleration;
					speed = Mathf.Min (maxSpeed, speed);
				}
			}
		} else if (Input.touchCount == 2 && deflect) {
			if (GameMaster_Deflect.shield > 0) {
				GameMaster_Deflect.shield -= Time.deltaTime * 20; //adjust to increase rate of shield drainage
				transform.GetChild (2).gameObject.SetActive (true);
			} else {
				transform.GetChild (2).gameObject.SetActive (false);
				recovering = true;
				StartCoroutine (ShieldRecover ());
			}
		}
	}

    public void Rotate(Vector3 direction){
        transform.RotateAround(core.transform.position, direction, speed * Time.deltaTime);
    }

	IEnumerator ShieldRecover(){
		yield return new WaitForSeconds (8);
		GameMaster_Deflect.shield = 100;
		recovering = false;
	}
}