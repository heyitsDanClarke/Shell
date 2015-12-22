using UnityEngine;
using System.Collections;

public class Bullet_Deflect : MonoBehaviour {

	public GameObject target;

	public float speed = 200;

	public bool collided = false;

	void Start(){
		Vector2 targetDirection = (Vector2)Vector3.Normalize (-transform.position - target.transform.position);
		GetComponent<Rigidbody2D> ().AddForce (targetDirection * speed);
	}

	void Update(){
		if (!this.GetComponent<Renderer> ().isVisible && collided)
			Destroy (this.gameObject);
	}
		
	void OnCollisionEnter2D(Collision2D other){
		collided = true;
		if (other.gameObject.tag == "wall") {
			GameMaster_Deflect.score += 100;
		}
	}
}
