using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudDisplayScript : MonoBehaviour {
    public Text barrelCountText;

    public Text enemyCountText;

    public Text detonatorCountText;

    public RawImage portraitFrame;
    public Texture2D portrait;
    public Texture2D detonationPortrait;
    [Range(0f, 10f)]
    public float portraitSwapTime = 1.5f;
    bool initialized = false;
	// Use this for initialization
	void Start () {
		
	}
	
    IEnumerator swapPortrait()
    {
        portraitFrame.texture = detonationPortrait;
        yield return new WaitForSeconds(portraitSwapTime);
        portraitFrame.texture = portrait;
        yield return null;
    }

    void OnDetonationTriggered()
    {
        StartCoroutine(swapPortrait());
    }
    void InitializeIfNeeded()
    {
        if (!initialized)
        {
            initialized = true;
            LevelSingleton.Instance.OnDetonationTriggered.AddListener(OnDetonationTriggered);
        }
    }
	// Update is called once per frame
	void Update () {
        InitializeIfNeeded();
        GameObject[] barrelsRemaining;
        barrelsRemaining = GameObject.FindGameObjectsWithTag("Barrel");
        barrelCountText.text = barrelsRemaining.Length.ToString();
        int detonatorCount = 0;
        foreach(GameObject barrel in barrelsRemaining)
        {
            if(barrel.GetComponent(typeof(Detonator))  != null)
            {
                detonatorCount++;
            }
        }
        detonatorCountText.text = detonatorCount.ToString();

        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCountText.text = enemies.Length.ToString();
    }
}
