using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour {

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
}
