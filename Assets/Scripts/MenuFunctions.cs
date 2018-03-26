using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour {

    public GameObject player;
    public GameObject pauseMenu;

    public void Pause()
    {
        Time.timeScale = 0;
        player.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        player.SetActive(true);
        pauseMenu.SetActive(false);
    }
    public void Replay()
    {
        //AdMobHandler.bannerView.Destroy ();
        SceneManager.LoadScene("Deflect");
    }
    public void Quit()
    {
        //AdMobHandler.bannerView.Destroy ();
        SceneManager.LoadScene("MainMenu");
    }
}
