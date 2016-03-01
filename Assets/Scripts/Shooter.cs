using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject bullet;
    public GameObject fastBullet;
    public GameObject slowBullet;

	float timer = 0;
	public float fireTime =2;
	Vector3 spawnPos;
	
	void Update () {
		timer += Time.deltaTime;
        if (timer >= fireTime)
        {
            timer = 0;
            int ammo = Random.Range(0, 10);
            if (ammo <= 1)
                Fire(fastBullet);
            else if (ammo <= 3)
                Fire(slowBullet);
            else
                Fire(bullet);
        }
	}

    void Fire(GameObject bullet)
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
        Instantiate(bullet, spawnPos, transform.rotation);
    }
}
