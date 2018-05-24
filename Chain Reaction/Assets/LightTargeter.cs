using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightTargeter : MonoBehaviour {

    public Transform target;
    float maxIntensity;
    float fadeTime = 0.4f;

	void Awake () {
        maxIntensity = GetComponent<Light>().intensity;
        GetComponent<Light>().intensity = 0f;
        fadeTime = GameSettings.Instance.LightTargeterFadeTime;

        // hack: unparent from the pirate so we don't get tossed around, but still allow us being in the pirate prefab
        if (transform.parent.GetComponent<Pirate>())
            transform.parent = transform.parent.parent; 
    }
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
	
	// Update is called once per frame
	void Update () {
        if (fadeTime <= 0f)
            return;
        var light = GetComponent<Light>();
        if (target)
        {
            transform.LookAt(target);
            if (light.intensity < maxIntensity)
            {
                light.intensity = Mathf.Min(light.intensity + Time.deltaTime / fadeTime, maxIntensity);
            }
        }
        else
        {
            if (light.intensity > 0f)
            {
                light.intensity = Mathf.Max(light.intensity - Time.deltaTime / fadeTime, 0f);
            }
        }
	}
}
