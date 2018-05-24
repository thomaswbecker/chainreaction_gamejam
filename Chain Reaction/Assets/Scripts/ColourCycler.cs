using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class ColourCycler : MonoBehaviour {
    public Color targetColour;
    [Range(0.1f, 10f)]
    public float frequency;
    Color originalColour;
    float startTime;
    float randomOffset;
	// Use this for initialization
	void Start () {
        originalColour = GetComponent<Light>().color;
        startTime = Time.time;
        randomOffset = Random.Range(0f, 2 * Mathf.PI);
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Light>().color = Color.Lerp(originalColour, targetColour,  0.5f + Mathf.Cos(randomOffset + (Time.time - startTime) * frequency * 2 * Mathf.PI) * -0.5f);
	}
}
