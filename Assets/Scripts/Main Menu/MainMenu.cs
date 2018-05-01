using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject tutorialText;

    GameObject player;
    GameObject walls;

    CanvasGroup canvasGroup;

    private void Awake()
    {
        Time.timeScale = 1;

        if (PlayerPrefs.GetInt("First Time", 0) == 0)
        {
            tutorialText.SetActive(true);
        }
    }

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        walls = player.transform.GetChild(1).gameObject;

        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Play()
    {
        StartCoroutine(LoadGame());
    }

    public void OpenShop()
    {

    }

    IEnumerator LoadGame()
    {
        while (player.transform.position.y != 0)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, Vector3.zero, Time.deltaTime);
            yield return null;
        }
        while (walls.transform.GetChild(1).GetComponent<SpriteRenderer>().color.a > 0)
        {
            foreach (Transform wall in walls.transform)
            {
                float newAlpha = wall.GetComponent<SpriteRenderer>().color.a - Time.deltaTime * 2;
                wall.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, newAlpha);
                yield return null;
            }
        }

        SceneManager.LoadScene("MainGame");
    }

    public void FadeCanvas()
    {
        canvasGroup.interactable = false;
        StartCoroutine(DoFade());
    }

    IEnumerator DoFade()
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime;
            yield return null;
        }
        canvasGroup.interactable = false;
    }
}
