using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    SpriteRenderer _sr;

    bool _isFriendly = false;
    public bool IsFriendly
    {
        get { return _isFriendly; }
        set
        {
            _isFriendly = value;
            if (_isFriendly)
                _sr.color = Color.white;
            else
                SetColourComplement(Camera.main.backgroundColor);
        }
    }
    public float speed = 1;

    GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
        _sr = GetComponent<SpriteRenderer>();
        GetComponent<Rigidbody2D>().velocity = (player.transform.position - transform.position).normalized * speed;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void SetColourComplement(Color inputColor)
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
