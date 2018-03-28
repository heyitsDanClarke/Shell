using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour {

    [HideInInspector]
    public Vector3 startingSize;

    private void Start()
    {
        startingSize = transform.localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            if (collision.gameObject.GetComponent<Bullet>().isFriendly)
            {
                GameManager.Instance.score += 1;
                transform.localScale = new Vector3(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f, transform.localScale.z);
                if (transform.localScale.x == 1.3f)
                    GameManager.Instance.NextLevel();
            }
            else
            {
                GameManager.Instance.health -= 1;
            }

            Destroy(collision.gameObject);
        }
    }
}
