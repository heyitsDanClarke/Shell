using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Bullet" && other.gameObject.GetComponent<Bullet_Deflect>().collided) {
			ShieldPickup ();
			Destroy (other.gameObject);
		}
	}

	void OnMouseDown(){
		ShieldPickup ();
	}

	void ShieldPickup(){
		if (GameMaster_Deflect.shield <= 80)
			GameMaster_Deflect.shield += 20;
		else
			GameMaster_Deflect.shield = 100;
		Destroy(this.gameObject);
	}
}