using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionModulator : MonoBehaviour {

    MeshRenderer[] renderers = null;
    float t;
	// Use this for initialization
	void Start () {
        
    }

    private void OnEnable()
    {
        t = 0f;
    }
    // Update is called once per frame
    void Update () {
        t += Time.deltaTime;
        Color baseColor = Color.red;
        float pulse01 = (-Mathf.Cos(12 * t) + 1) * 0.5f;
        float factor = pulse01 * 0.4f;
        Color finalColor = baseColor * factor;
		if (renderers == null)
            renderers = GetComponentsInChildren<MeshRenderer>();
        foreach (var renderer in renderers)
        {
            renderer.material.SetColor("_EmissionColor", finalColor);
        }
    }
}
