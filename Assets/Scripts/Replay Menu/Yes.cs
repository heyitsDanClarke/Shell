using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Yes : MonoBehaviour {

	public void Replay(){
		//AdMobHandler.bannerView.Destroy ();
		SceneManager.LoadScene ("Deflect");
	}
}
