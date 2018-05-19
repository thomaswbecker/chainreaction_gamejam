using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour {

    private static int numberOfLevels = 5;

    private static int currentLevel = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public static void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public static void LevelSelect()
    {
        SceneManager.LoadScene("Level Pick Menu");
    }

    public static void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public static void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public static void ReLoadLevel()
    {
        LoadLevel(currentLevel);
    }

    public static bool HasNextLevel()
    {
        return currentLevel < numberOfLevels;
    }

    public static void LoadNextLevel()
    {
        if(HasNextLevel())
        {
            currentLevel++;
            LoadLevel(currentLevel);
        }
    }

    public static void LoadLevel(int levelNumber)
    {
        currentLevel = levelNumber;
        SceneManager.LoadScene("Level " + levelNumber);
        SceneManager.LoadScene("Pause Menu", LoadSceneMode.Additive);
        SceneManager.LoadScene("Level HUD", LoadSceneMode.Additive);
    }

    public void SwitchToMainMenu()
    {
        MainMenu();
    }

    public void SwtichToLevelSelect()
    {
        LevelSelect();
    }

    public void SwitchToCredits()
    {
        Credits();
    }

    public void SwitchToInstructions()
    {
        Instructions();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SwitchToLevel(int levelNumber)
    {
        LoadLevel(levelNumber);
    }
}
