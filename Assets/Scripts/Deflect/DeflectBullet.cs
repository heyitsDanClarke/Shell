using UnityEngine;
using System.Collections;

public class DeflectBullet : MonoBehaviour {

	public GameObject target;

	public float speed = 200;

	public bool collided = false;

	void Start(){
		Vector2 targetDirection = Vector3.Normalize (-transform.position - target.transform.position);
		GetComponent<Rigidbody2D> ().AddForce (targetDirection * speed);
	}

	void FixedUpdate(){
		if (!GetComponent<Renderer>().isVisible && collided)
			Destroy (gameObject);
	}
		
	void OnCollisionEnter2D(Collision2D other){
		collided = true;
		if (other.gameObject.tag == "Wall") {
			DeflectLogic.Instance.score += 1;
            other.gameObject.GetComponent<Flash>().Flasher();
		}
		if (other.gameObject.tag == "Shield") {
			DeflectLogic.Instance.score += 1;
			other.gameObject.GetComponent<Flash>().Flasher();
		}
	}
}
