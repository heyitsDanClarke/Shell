using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Bullet" && other.gameObject.GetComponent<DeflectBullet>().collided) {
			ShieldPickup ();
			Destroy (other.gameObject);
		}
	}

	public void ShieldPickup(){
		if (DeflectLogic.Instance.shield <= 80)
			DeflectLogic.Instance.shield += 20;
		else
			DeflectLogic.Instance.shield = 100;
		Destroy(gameObject);
	}
}