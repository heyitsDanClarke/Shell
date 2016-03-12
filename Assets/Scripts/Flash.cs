using UnityEngine;
using System.Collections;

public class Flash : MonoBehaviour
{
    public Color flashColor;

    Color originalColor;

    void Start()
    {
        originalColor = this.GetComponent<SpriteRenderer>().color;
    }


    public IEnumerator Flasher()
    {
        this.GetComponent<SpriteRenderer>().color = originalColor;
        
        GetComponent<SpriteRenderer>().color = flashColor;
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().color = originalColor;
           
    }
}