using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudDisplayScript : MonoBehaviour {
    public Text barrelCountText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] barrelsRemaining;
        barrelsRemaining = GameObject.FindGameObjectsWithTag("Barrel");
        barrelCountText.text = barrelsRemaining.Length.ToString();
    }
}
