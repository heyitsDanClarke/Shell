using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class WallControls : MonoBehaviour {

	public float speed = 200;

	void Update(){
		if(Input.GetKey("a") || Input.GetKey("left"))
			Rotate (Vector3.forward);
		if(Input.GetKey("d") || Input.GetKey("right"))
			Rotate (Vector3.back);

        if(Input.touches.Length > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2)
                Rotate(Vector3.forward);
            else
                Rotate(Vector3.back);
        }
    }

    public void Rotate(Vector3 direction){
        transform.Rotate(direction, speed * Time.deltaTime);
    }
}