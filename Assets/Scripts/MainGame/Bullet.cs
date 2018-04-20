using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    SpriteRenderer _sr;

    public bool isFriendly = false;
    public float speed = 1;

    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        _sr = GetComponent<SpriteRenderer>();
        if (!isFriendly)
            SetColourComplement(Camera.main.backgroundColor);
        GetComponent<Rigidbody2D>().velocity = (player.transform.position - transform.position).normalized * speed;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void SetColourComplement(Color inputColor)
    {
        float tempH, tempS, tempV;
        Color.RGBToHSV(inputColor, out tempH, out tempS, out tempV);
        float newH = (tempH + 0.5f) % 1;
        Color tempColor = Color.HSVToRGB(newH, tempS, tempV);

        _sr.color = tempColor;

        Gradient tempGrad = new Gradient();

        GradientColorKey[] gck = new GradientColorKey[2];
        gck[0].color = tempColor;
        gck[0].time = 0;
        gck[1].color = tempColor;
        gck[1].time = 1;

        GradientAlphaKey[] gak = new GradientAlphaKey[2];
        gak[0].alpha = 1;
        gak[0].time = 0;
        gak[1].alpha = 0;
        gak[1].time = 1;

        tempGrad.SetKeys(gck, gak);

        GetComponent<TrailRenderer>().colorGradient = tempGrad;
    }
}
