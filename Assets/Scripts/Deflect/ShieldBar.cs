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
        rect = this.GetComponent<RectTransform>();
        originalSizeX = rect.sizeDelta.x;
    }

    void Update()
    {
        rect.sizeDelta = new Vector2(originalSizeX * (GameMaster_Deflect.shield/100), rect.sizeDelta.y);

		if (GameMaster_Deflect.shield <= 20)
			lowShield = true;
		else
			lowShield = false;

		if (lowShield) {
			Pulse ();
		} else if(this.GetComponent<Image>().color != Color.white) {
			ResetColor ();
		}
    }

	void Pulse(){
		this.GetComponent<Image> ().color = Color.Lerp (this.GetComponent<Image> ().color, targetColor, 20 * Time.deltaTime);
		shieldFrame.GetComponent<Image> ().color = Color.Lerp (this.GetComponent<Image> ().color, targetColor, 20 * Time.deltaTime);

		if (this.GetComponent<Image> ().color == targetColor) {
			if (targetColor == pulseColor)
				targetColor = Color.white;
			else
				targetColor = pulseColor;
		}
	}

	public void ResetColor(){
		this.GetComponent<Image> ().color = Color.white;
		shieldFrame.GetComponent<Image> ().color = Color.white;
	}
}