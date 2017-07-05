using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject tutorialText;

    GameObject player;
    GameObject walls;
    GameObject core;

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
        core = player.transform.GetChild(0).gameObject;
        walls = player.transform.GetChild(1).gameObject;

        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void SelectAbsorb()
    {
        StartCoroutine(LoadAbsorb());
    }

    IEnumerator LoadAbsorb()
    {
        while (player.transform.position.y != 0)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, Vector3.zero, Time.deltaTime);
            yield return null;
        }
        while (core.transform.localScale.x > 0.3f)
        {
            float newX = core.transform.localScale.x - Time.deltaTime / 2;
            float newY = core.transform.localScale.y - Time.deltaTime / 2;
            core.transform.localScale = new Vector3(newX, newY, 1);
            yield return null;
        }
        SceneManager.LoadScene("Absorb");
    }

    public void SelectDeflect()
    {
        StartCoroutine(LoadDeflect());
    }

    IEnumerator LoadDeflect()
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

        SceneManager.LoadScene("Deflect");
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
