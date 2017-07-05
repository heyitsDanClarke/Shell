using UnityEngine;
using System.Collections;

public class AbsorbBody : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Bullet") {
			Destroy(other.gameObject);
            transform.localScale = new Vector3 (this.transform.localScale.x + 0.1f,
                transform.localScale.y + 0.1f, 0);
		}
	}
}
