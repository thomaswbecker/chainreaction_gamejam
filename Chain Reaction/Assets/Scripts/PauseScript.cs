using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

    private bool paused = false;

    private bool levelDone = false;

    private float endOfGameTimerStart = 0f;

    private static float explosionWait = 3f;

    private int previousBarrelsLeft = 0;

    private bool endGameStarted = false;

    private bool levelOver = false;

    public GameObject pauseMenu;

    public Button restartLevelButton;

    public Button mainMenuButton;

    public Button levelSelectButton;

    public Button nextLevelButton;

    public Text titleText;

    public AudioClip failAudio;

    public AudioClip successAudio;

    public AudioSource audioSource;

    public RawImage portraitFrame;

    public RawImage portrait;

    public RawImage sparkleFrame;

    public Texture2D sadFace;

    public Texture2D happyFace;


    // Use this for initialization
    void Start () {
        pauseMenu.SetActive(false);

        restartLevelButton.onClick.AddListener(RestartLevel);

        mainMenuButton.onClick.AddListener(MainMenu);

        levelSelectButton.onClick.AddListener(LevelSelect);

        nextLevelButton.onClick.AddListener(NextLevel);

        nextLevelButton.gameObject.SetActive(false);

        portraitFrame.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!levelOver)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                paused = !paused;

                if (paused)
                {
                    Pause();
                }
                else
                {
                    Unpause();
                }
            }

            CheckEndGame();
        }
    }
    float endTime;
    float sparkleVisibility = 0f;

    private void CheckEndGame()
    {
        GameObject[] barrelsRemaining;
        barrelsRemaining = GameObject.FindGameObjectsWithTag("Barrel");
        int barrelCount = barrelsRemaining.Length;
        int detonatorCount = 0;
        foreach (GameObject barrel in barrelsRemaining)
        {
            if (barrel.GetComponent(typeof(Detonator)) != null)
            {
                detonatorCount++;
            }
        }

        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int enemiesAlive = enemies.Length;

        if(enemiesAlive == 0 || detonatorCount == 0)
        {
            if(!endGameStarted || barrelCount != previousBarrelsLeft)
            {
                previousBarrelsLeft = barrelCount;
                endOfGameTimerStart = Time.timeSinceLevelLoad;

                endGameStarted = true;
            }

            if(endOfGameTimerStart + explosionWait < Time.timeSinceLevelLoad)
            {
                if(enemiesAlive > 0)
                {
                    levelFailure();
                } else
                {
                    levelSuccess();
                }
            }

        }
    }

    private void levelSuccess()
    {
        audioSource.PlayOneShot(successAudio);
        nextLevelButton.gameObject.SetActive(true);
        Pause();
        titleText.text = "Level Passed";
        portraitFrame.gameObject.SetActive(true);
        levelOver = true;
        portrait.texture = happyFace;
        //sparkleFrame.gameObject.SetActive(true);
    }

    private void levelFailure()
    {
        audioSource.PlayOneShot(failAudio);
        Pause();
        titleText.text = "Level Failed";
        levelOver = true;
        portraitFrame.gameObject.SetActive(true);
        portrait.texture = sadFace;
        sparkleFrame.gameObject.SetActive(false);
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

    public void NextLevel()
    {
        Unpause();
        MenuNavigation.LoadNextLevel();
    }

    public void MainMenu()
    {
        Unpause();
        MenuNavigation.MainMenu();
    }
}
