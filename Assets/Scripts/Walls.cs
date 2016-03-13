using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Walls : MonoBehaviour {

	public float speed = 200;
	public GameObject core;

	bool deflect = false;

	GameObject shield;

	bool recovering = false;

	float timer = 0;

	void Start(){
		if (SceneManager.GetActiveScene().name == "Deflect")
			deflect = true;
		shield = transform.GetChild (2).gameObject;
	}

	void Update(){
		timer += Time.fixedDeltaTime;
		if(Input.GetKey("a") || Input.GetKey("left"))
			Rotate (Vector3.forward);
		if(Input.GetKey("d") || Input.GetKey("right"))
			Rotate (Vector3.back);

		if (Input.touchCount < 2) {
			if (deflect) {
				ShieldShrink ();
                if (GameMaster_Deflect.shield < 100 && !recovering)
                    GameMaster_Deflect.shield += Time.deltaTime * 2; //adjust to change shield recovery
			}
			if (Input.touchCount == 1 && !EventSystem.current.IsPointerOverGameObject (Input.GetTouch (0).fingerId)) {
				if (Input.GetTouch (0).position.x < Screen.width / 2)
					Rotate (Vector3.forward);
				else if (Input.GetTouch (0).position.x > Screen.width / 2)
					Rotate (Vector3.back);
			}
		} else if (Input.touchCount == 2 && deflect) {
			if (GameMaster_Deflect.shield > 0) {
				ShieldGrow ();
				GameMaster_Deflect.shield -= Time.deltaTime * 50; //adjust to increase rate of shield drainage
			} else {
				ShieldShrink ();
				if (!recovering) {
					recovering = true;
					StartCoroutine (ShieldRecover (8));
				}
			}
		}
	}

    public void Rotate(Vector3 direction){
        transform.RotateAround(core.transform.position, direction, speed * Time.deltaTime);
    }

	IEnumerator ShieldRecover(int recoveryTime){
		yield return new WaitForSeconds (recoveryTime);
		if (recoveryTime > 2) {
			GameMaster_Deflect.shield = 100;
			recovering = false;
		} else {

		}
	}

	void ShieldGrow(){
		shield.SetActive (true);
		if (shield.transform.localScale.x < 0.8f)
			shield.transform.localScale = new Vector3 (shield.transform.localScale.x + Time.deltaTime*5, shield.transform.localScale.y + Time.deltaTime*5, 1);
		else {
			transform.GetChild(0).gameObject.SetActive(false);
			transform.GetChild(1).gameObject.SetActive(false);
		}
	}

	void ShieldShrink(){
		transform.GetChild(0).gameObject.SetActive(true);
		transform.GetChild(1).gameObject.SetActive(true);
		if (shield.transform.localScale.x > 0.49f)
			shield.transform.localScale = new Vector3 (shield.transform.localScale.x - Time.deltaTime*5, shield.transform.localScale.y - Time.deltaTime*5, 1);
		else
			shield.SetActive (false);
	}
}