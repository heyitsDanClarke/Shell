using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    SpriteRenderer _sr;

    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        SetColourComplement();
    }

    void Update () {
        SetColourComplement(); //remove later
	}

    void SetColourComplement()
    {
        float hueHolder,satHolder,value = -1;
        Color.RGBToHSV(Camera.main.backgroundColor, out hueHolder, out satHolder, out value);
        hueHolder *= 360;
        hueHolder = (hueHolder + 180) % 360;
        hueHolder /= 360;
        _sr.color = Color.HSVToRGB(1-hueHolder, satHolder, value);
    } 
}
