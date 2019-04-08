using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public float speed = 1;

    private void Update()
    {
        Rotate(true);
    }

    public void Rotate(bool clockwise)
    {
        foreach(Transform child in transform)
        {
            if(child.position.y == 1.5 && child.position.x < 1.5)
            {
                child.position = new Vector2(child.position.x + 0.5f, 1.5f);
            }
        }
    }
}
