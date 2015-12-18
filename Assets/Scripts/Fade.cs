using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

    CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Fade_Canvas()
    {
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
        yield return null;
    }
}
