using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject bullet;

	bool fireReady = false;
	float timer = 0;
	public float fireTime =2;
	Vector3 spawnPos;
	

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= fireTime) {
			fireReady = true;
			timer = 0;
		}
		if (fireReady) {
			int shootWall = Random.Range(0,4);
			if(shootWall == 0){ //left
				spawnPos = new Vector3(0, Random.Range(0f,1f),1);
			}
			else if (shootWall == 1){ //top
				spawnPos = new Vector3(Random.Range(0f,1f),1,1);
			}
			else if (shootWall == 2){ //right
				spawnPos = new Vector3(1, Random.Range(0f,1f),1);
			}
			else { //bottom
				spawnPos = new Vector3(Random.Range(0f,1f),0,1);
			}
			spawnPos = Camera.main.ViewportToWorldPoint(spawnPos);
			Instantiate(bullet, spawnPos, transform.rotation);
			fireReady = false;
		}
	}
}
