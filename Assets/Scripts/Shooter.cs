using UnityEngine;
using System.Collections.Generic;

public class Shooter : MonoBehaviour {

    public GameObject bullet;

    List<GameObject> spawnedEnemyBullets;

	float timer = 0;
	public float fireTime =2;
	Vector3 spawnPos;

    private void Start()
    {
        spawnedEnemyBullets = new List<GameObject>();
    }

    void Update () {
		timer += Time.deltaTime;
        if (timer >= fireTime)
        {
            timer = 0;
            int rand = Random.Range(0, 10);
            if (rand > 1)
                Fire(bullet, false);
            else
                Fire(bullet, true);
        }
	}

    void Fire(GameObject bullet, bool friendly)
    {
        int shootWall = Random.Range(0, 4);
        if (shootWall == 0)
        { //left
            spawnPos = new Vector3(0, Random.Range(0f, 1f), 1);
        }
        else if (shootWall == 1)
        { //top
            spawnPos = new Vector3(Random.Range(0f, 1f), 1, 1);
        }
        else if (shootWall == 2)
        { //right
            spawnPos = new Vector3(1, Random.Range(0f, 1f), 1);
        }
        else
        { //bottom
            spawnPos = new Vector3(Random.Range(0f, 1f), 0, 1);
        }
        spawnPos = Camera.main.ViewportToWorldPoint(spawnPos);
        GameObject spawnedBullet = Instantiate(bullet, spawnPos, Quaternion.identity);
        spawnedBullet.GetComponent<Bullet>().isFriendly = friendly;
    }
}
