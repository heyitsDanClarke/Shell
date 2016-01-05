using UnityEngine;
using System.Collections;

public class ShieldBar : MonoBehaviour {
    
    RectTransform rect;

    float originalSizeX;

    void Start()
    {
        rect = this.GetComponent<RectTransform>();
        originalSizeX = rect.sizeDelta.x;
    }

    void Update()
    {
        rect.sizeDelta = new Vector2(originalSizeX * (GameMaster_Deflect.shield/100), rect.sizeDelta.y);
    }
}
