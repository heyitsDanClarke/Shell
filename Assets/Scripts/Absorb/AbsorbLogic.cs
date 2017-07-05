using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbsorbLogic : MonoBehaviour {

    public static AbsorbLogic Instance;

	public int level = 1;
	int highestLevel;

	float timerValue;
	Text timer;
	Text levelDisplay;
	Text highestLevelDisplay;

	GameObject player;
	public GameObject replayMenu;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    void Start(){
		PlayerPrefs.SetInt ("First Time", 1);

		timerValue = 30;
		level = 1;
		Time.timeScale = 1;

		timer = GameObject.Find ("Timer").GetComponent<Text>();
		levelDisplay = GameObject.Find ("Level").GetComponent<Text>();
		highestLevelDisplay = GameObject.Find ("High Level").GetComponent<Text>();

		highestLevel = PlayerPrefs.GetInt("Highest Level",0);
		highestLevelDisplay.text = "Highest level: " + highestLevel.ToString();

		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update(){
		if (timerValue >= 1) {
			if (player.transform.GetChild (0).transform.localScale.y >= 1.3f) {
				level += 1;
				levelDisplay.text = "Level: " + level.ToString ();
				if (level > highestLevel) {
					PlayerPrefs.SetInt ("Highest Level", level);
					highestLevel = level;
					highestLevelDisplay.text = "Highest level: " + highestLevel.ToString ();
				}
				player.transform.GetChild (0).transform.localScale = new Vector3 (0.3f, 0.3f, 0);
				timerValue = 30;
			}
			timerValue -= Time.deltaTime;
			timer.text = timerValue.ToString ("0");
		} else {
			timer.text = "Game Over";
			Time.timeScale = 0;
			GameObject.Find ("Menu").GetComponent<Button>().interactable = false;
			foreach (GameObject go in GameObject.FindGameObjectsWithTag("Bullet"))
				Destroy (go);
			player.SetActive (false);
			replayMenu.SetActive (true);
		}
	}
}
