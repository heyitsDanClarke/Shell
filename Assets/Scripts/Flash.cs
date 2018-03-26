using UnityEngine;
using System.Collections;

public class Flash : MonoBehaviour
{
    public Color flashColor;

    Color originalColor;
    bool flashed = false;
    float timer;

    void Start()
    {
        originalColor = GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        if (!flashed)
        {
            return;
        }

        else
        {
            timer += Time.deltaTime;
            if (timer >= 0.1f)
            {
                flashed = false;
                timer = 0;
                GetComponent<SpriteRenderer>().color = originalColor;
            }
        }
    }

    public void Flasher()
    {
        GetComponent<SpriteRenderer>().color = flashColor;
        flashed = true;
           
    }
}