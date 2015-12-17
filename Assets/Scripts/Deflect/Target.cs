using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	int bonus;
	
	void Start () {
		bonus = Random.Range (2, 6);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Bullet" && other.gameObject.GetComponent<Bullet_Deflect>().collided) {
			GameMaster_Deflect.score += 100 * bonus;
			Destroy(this.gameObject);
			Destroy (other.gameObject);
		}
	}
}
