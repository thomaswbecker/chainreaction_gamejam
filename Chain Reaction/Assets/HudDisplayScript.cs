using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudDisplayScript : MonoBehaviour {
    public Text barrelCountText;

    public Text enemyCountText;

    public Text detonatorCountText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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
