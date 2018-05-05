using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectButtonController : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void loadScene(string levelScene)
    {
        SceneManager.LoadScene(levelScene);
        SceneManager.LoadScene("Pause Menu", LoadSceneMode.Additive);
        SceneManager.LoadScene("Level HUD", LoadSceneMode.Additive);
    }
}
