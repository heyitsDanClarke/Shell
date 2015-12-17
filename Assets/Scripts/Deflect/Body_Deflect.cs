using UnityEngine;
using System.Collections;

public class Body_Deflect : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Bullet") {
			Destroy(other.gameObject);
			GameMaster_Deflect.health -= 1;
		}
	}
}