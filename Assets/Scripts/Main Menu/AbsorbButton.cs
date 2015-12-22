using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AbsorbButton : MonoBehaviour {

    GameObject player;
	GameObject core;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
		core = player.transform.GetChild (0).gameObject;
    }

    public void ChangeLevel()
    {
        StartCoroutine(NewLevel());
    }

    IEnumerator NewLevel()
    {
        while (player.transform.position.y != 0)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, Vector3.zero, Time.deltaTime);
            yield return null;
        }
		while (core.transform.localScale.x > 0.3f) {
			float newX = core.transform.localScale.x - Time.deltaTime/2;
			float newY = core.transform.localScale.y - Time.deltaTime/2;
			core.transform.localScale = new Vector3 (newX, newY, 1);
			yield return null;
		}
        SceneManager.LoadScene("Absorb");
		//yield return null;
    }
}
