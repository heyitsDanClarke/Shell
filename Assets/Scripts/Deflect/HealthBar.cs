using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

    public GameObject[] healthBars;

    void Start()
    {
        healthBars = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            healthBars[i] = transform.GetChild(i).gameObject;
        }
    }

    public void ShowDamage(int health)
    {
        healthBars[health].SetActive(false);
    }
}
