using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPopUp : MonoBehaviour {


    public float startT;
    public Canvas canvas;
	// Use this for initialization
	void Start () {
        startT = Time.time + 3f;
        canvas = GetComponent<Canvas>();

    }
	
	// Update is called once per frame
	void Update () {
		if( Time.time - startT > 5f)
        {
            canvas.enabled = false;
        }
        
	}
}
