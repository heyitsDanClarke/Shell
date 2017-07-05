using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class WallControls : MonoBehaviour {

	public float speed = 200;
    public float shieldRecovery = 20;
    public float shieldDrain = 50;

	bool deflect = false;

	GameObject shield;

	bool recovering = false;

	float timer = 0;
	int rechargeTimer = 2;

	void Start(){
        if (SceneManager.GetActiveScene().name == "Deflect")
        {
            deflect = true;
            shield = transform.GetChild(2).gameObject;
        }
	}

	void Update(){
		timer += Time.deltaTime;

		if (timer < rechargeTimer) {
			recovering = true;
		} else {
			recovering = false;
			if (rechargeTimer >= 6) {
				DeflectLogic.Instance.shield = 100;
				rechargeTimer = 2;
			}
		}
		if (DeflectLogic.Instance.shield < 100 && !recovering)
			DeflectLogic.Instance.shield += Time.deltaTime * shieldRecovery; //adjust to change shield recovery
		
		if(Input.GetKey("a") || Input.GetKey("left"))
			Rotate (Vector3.forward);
		if(Input.GetKey("d") || Input.GetKey("right"))
			Rotate (Vector3.back);

		if (Input.touchCount < 2) {
			if (deflect) {
				ShieldShrink ();
			}
			if (Input.touchCount == 1 && !EventSystem.current.IsPointerOverGameObject (Input.GetTouch (0).fingerId)) {
				if (Input.GetTouch (0).position.x < Screen.width / 2)
					Rotate (Vector3.forward);
				else if (Input.GetTouch (0).position.x > Screen.width / 2)
					Rotate (Vector3.back);
			}
		} else if (Input.touchCount >= 2 && deflect) {
			if(DeflectLogic.Instance.shield > 0)
				timer = 0;
			if (DeflectLogic.Instance.shield > 0) {
				ShieldGrow ();
				DeflectLogic.Instance.shield -= Time.deltaTime * shieldDrain; //adjust to increase rate of shield drainage
			} else {
				ShieldShrink ();
				rechargeTimer = 6;
			}
		}
	}

    public void Rotate(Vector3 direction){
        transform.Rotate(direction, speed * Time.deltaTime);
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