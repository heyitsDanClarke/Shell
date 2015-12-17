using UnityEngine;
using System.Collections;

public class Body_Absorb : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Bullet") {
			Destroy(other.gameObject);
			this.transform.localScale = new Vector3 (this.transform.localScale.x + 0.1f,
				this.transform.localScale.y + 0.1f, 0);
		}
	}
}
