using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

    private bool paused = false;

    public GameObject pauseMenu;

    public Button restartLevelButton;

    public Button mainMenuButton;

    public Button levelSelectButton;

	// Use this for initialization
	void Start () {
        pauseMenu.SetActive(false);

        restartLevelButton.onClick.AddListener(RestartLevel);

        mainMenuButton.onClick.AddListener(MainMenu);

        levelSelectButton.onClick.AddListener(LevelSelect);
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
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
        MenuNavigation.ReLoadLevel();
    }

    public void LevelSelect()
    {
        Unpause();
        MenuNavigation.LevelSelect();
    }

    public void MainMenu()
    {
        Unpause();
        MenuNavigation.MainMenu();
    }
}
