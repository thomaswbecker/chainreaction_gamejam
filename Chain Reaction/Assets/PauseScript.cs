using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

    private bool paused = false;

    public GameObject pauseMenu;

	// Use this for initialization
	void Start () {
        pauseMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;

            if(paused)
            {
                Pause();
            } else
            {
                Unpause();
            }
        }
	}

    private void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    private void Unpause()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void RestartLevel() {
        Unpause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
