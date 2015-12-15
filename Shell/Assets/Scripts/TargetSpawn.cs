using UnityEngine;
using System.Collections;

public class TargetSpawn : MonoBehaviour {

	public GameObject targetPrefab;

	float timer = 0;

	public float spawnTime = 5;

	Vector3 spawnPos;

	GameObject spawnedTarget;

	void Update(){
		timer += Time.deltaTime;
		if (timer >= spawnTime) {
			if(spawnedTarget != null)
				Destroy(spawnedTarget);
			int spawnSide = Random.Range(0,4);
			if(spawnSide == 0){ //left
				spawnPos = new Vector3(0.25f, Random.Range(0.1f,0.9f),1);
			}
			else if (spawnSide == 1){ //top
				spawnPos = new Vector3(Random.Range(0.1f,0.9f),0.75f,1);
			}
			else if (spawnSide == 2){ //right
				spawnPos = new Vector3(0.75f, Random.Range(0.1f,0.9f),1);
			}
			else { //bottom
				spawnPos = new Vector3(Random.Range(0.1f,0.9f),0.25f,1);
			}
			spawnPos = Camera.main.ViewportToWorldPoint(spawnPos);
			spawnedTarget = (GameObject)Instantiate(targetPrefab,spawnPos,this.transform.rotation);
			timer = 0;
		}
	}
}
