using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeflectButton : MonoBehaviour {

    GameObject player;
	GameObject walls;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
		walls = player.transform.GetChild (1).gameObject;
    }

	public void ChangeLevel(){
        StartCoroutine(NewLevel());
	}

    IEnumerator NewLevel()
    {
        while (player.transform.position.y != 0)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, Vector3.zero, Time.deltaTime);
            yield return null;
        }
		while (walls.transform.GetChild (1).GetComponent<SpriteRenderer> ().color.a > 0) {
			foreach (Transform wall in walls.transform) {
				float newAlpha = wall.GetComponent<SpriteRenderer> ().color.a - Time.deltaTime*2;
				wall.GetComponent<SpriteRenderer> ().color = new Color(255,255,255,newAlpha);
				yield return null;
			}
		}

        SceneManager.LoadScene("Deflect");
        //yield return null;
    }
}
