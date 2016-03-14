using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public GameObject[] healthBars;

	bool lowHealth = false;

	public Color pulseColor;
	Color targetColor;

    void Start()
    {
		targetColor = pulseColor;
        healthBars = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            healthBars[i] = transform.GetChild(i).gameObject;
        }
    }

	void Update(){
		if (GameMaster_Deflect.health <= 2)
			lowHealth = true;
		else
			lowHealth = false;
		if (lowHealth)
			Pulse ();
	}

    public void ShowDamage(int health)
    {
        healthBars[health].SetActive(false);
    }

	void Pulse(){
		this.GetComponent<Image> ().color = Color.Lerp (this.GetComponent<Image> ().color, targetColor, 20 * Time.deltaTime);
		foreach(var bar in healthBars)
			bar.GetComponent<Image>().color = Color.Lerp (this.GetComponent<Image> ().color, targetColor, 20 * Time.deltaTime);

		if (this.GetComponent<Image> ().color == targetColor) {
			if (targetColor == pulseColor)
				targetColor = Color.white;
			else
				targetColor = pulseColor;
		}
	}

	public void ResetColor(){
		this.GetComponent<Image> ().color = Color.white;
		foreach (var bar in healthBars) {
			bar.GetComponent<Image> ().color = Color.white;
		}
	}
}