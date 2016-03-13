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
        originalColor = this.GetComponent<SpriteRenderer>().color;
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
                this.GetComponent<SpriteRenderer>().color = originalColor;
            }
        }
    }

    public void Flasher()
    {
        this.GetComponent<SpriteRenderer>().color = flashColor;
        flashed = true;
           
    }
}