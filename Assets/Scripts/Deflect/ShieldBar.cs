using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour {
    
    RectTransform rect;

    float originalSizeX;

	public GameObject shieldFrame;

	bool lowShield = false;

	public Color pulseColor;
	Color targetColor;

    void Start()
    {
		targetColor = pulseColor;
        rect = GetComponent<RectTransform>();
        originalSizeX = rect.sizeDelta.x;
    }

    void FixedUpdate()
    {
        rect.sizeDelta = new Vector2(originalSizeX * (DeflectLogic.Instance.shield/100), rect.sizeDelta.y);

		if (DeflectLogic.Instance.shield <= 20)
			lowShield = true;
		else
			lowShield = false;

		if (lowShield) {
			Pulse ();
		} else if(GetComponent<Image>().color != Color.white) {
			ResetColor ();
		}
    }

	void Pulse(){
        GetComponent<Image>().color = Color.Lerp (GetComponent<Image>().color, targetColor, 20 * Time.deltaTime);
		shieldFrame.GetComponent<Image> ().color = Color.Lerp (GetComponent<Image>().color, targetColor, 20 * Time.deltaTime);

		if (GetComponent<Image>().color == targetColor) {
			if (targetColor == pulseColor)
				targetColor = Color.white;
			else
				targetColor = pulseColor;
		}
	}

	public void ResetColor(){
        GetComponent<Image>().color = Color.white;
		shieldFrame.GetComponent<Image> ().color = Color.white;
	}
}