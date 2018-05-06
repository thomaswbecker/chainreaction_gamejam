using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTimerText: MonoBehaviour {
    public TextMesh textMesh;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        string timeValue = (detonationTimestamp - Time.time).ToString("0.0");

        // set text
        if (detonationTimestamp < Time.time)
            this.enabled = false;

        var cameraPosition = LevelSingleton.Instance.GameCamera.transform.position;
        var distance = (cameraPosition - transform.position).magnitude;
        transform.localScale = determineScale(distance);
        textMesh.text = timeValue;
        //Vector3 textRotation = Quaternion.LookRotation(transform.position - cameraPosition);
        textMesh.transform.rotation = LevelSingleton.Instance.GameCamera.transform.rotation;
        // TODO: rotate to face camera.

    }

    private Vector3 determineScale(float cameraDistance)
    {
        float scale = cameraDistance * 0.1f;
        return new Vector3(scale, scale, scale);
    }
    private float detonationTimestamp = 0f;
    public void StartCountdown(float seconds)
    {
        this.enabled = true;
        detonationTimestamp = Time.time + seconds;
    }

    private void OnEnable()
    {
        //textMesh.gameObject.SetActive(true);
        // TODO: make element visible
    }
    private void OnDisable()
    {
        //textMesh.gameObject.SetActive(true);
        // TODO: make element invisible
    }
}
