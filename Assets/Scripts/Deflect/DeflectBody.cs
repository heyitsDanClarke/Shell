using UnityEngine;
using System.Collections;

public class DeflectBody : MonoBehaviour {

    GameObject healthBar;

    void Start()
    {
        healthBar = GameObject.Find("Health");
    }

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Bullet") {
			Destroy(other.gameObject);
			DeflectLogic.Instance.health -= 1;
            healthBar.GetComponent<HealthBar>().ShowDamage(DeflectLogic.Instance.health);
            GetComponent<Flash>().Flasher();
		}
	}
}