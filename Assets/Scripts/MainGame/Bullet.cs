using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    SpriteRenderer _sr;

    public bool isFriendly = false;

    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        if (!isFriendly)
            SetColourComplement(Camera.main.backgroundColor);
    }

    void SetColourComplement(Color inputColor)
    {
        float tempH, tempS, tempV;
        Color.RGBToHSV(inputColor, out tempH, out tempS, out tempV);
        float newH = (tempH + 0.5f) % 1;
        _sr.color = Color.HSVToRGB(newH, tempS, tempV);
    } 
}
