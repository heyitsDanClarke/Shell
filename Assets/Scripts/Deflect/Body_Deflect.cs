using UnityEngine;
using System.Collections;

public class Body_Deflect : MonoBehaviour {

    GameObject healthBar;

    void Start()
    {
        healthBar = GameObject.Find("Health");
    }

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Bullet") {
			Destroy(other.gameObject);
			GameMaster_Deflect.health -= 1;
            healthBar.GetComponent<HealthBar>().ShowDamage(GameMaster_Deflect.health);
            this.GetComponent<Flash>().Flasher();
		}
	}
}