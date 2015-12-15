using UnityEngine;
using System.Collections;

public class Body : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "bullet") {
			Destroy(other.gameObject);
			GameMaster.health -= 1;
		}
	}
}