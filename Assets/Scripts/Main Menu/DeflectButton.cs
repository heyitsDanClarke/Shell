using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeflectButton : MonoBehaviour {

    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
        SceneManager.LoadScene("Deflect");
        yield return null;
    }
}
