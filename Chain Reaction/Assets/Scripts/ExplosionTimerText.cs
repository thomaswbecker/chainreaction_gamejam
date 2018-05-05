using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTimerText: MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        string timeValue = (Time.time - detonationTimestamp).ToString();

        // set text
        if (detonationTimestamp < Time.time)
            this.enabled = false;
	}
    private float detonationTimestamp = 0f;
    public void StartCountdown(float seconds)
    {
        this.enabled = true;
        detonationTimestamp = Time.time + seconds;
    }

    private void OnEnable()
    {
        // TODO: make element visible
    }
    private void OnDisable()
    {
        // TODO: make element invisible
    }
}
