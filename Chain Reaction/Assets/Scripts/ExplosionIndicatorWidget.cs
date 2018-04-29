using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionIndicatorWidget : MonoBehaviour {
    float enableTime;
    private void OnEnable()
    {
        enableTime = Time.time;
        GetComponent<MeshRenderer>().enabled = true;
    }
    private void OnDisable()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
    // Update is called once per frame
    void Update () {
        float enabledTime = Time.time - enableTime;
        float rampTime = 0.5f;
        float rampT = 1 / rampTime;
        float ramp = Mathf.Clamp01(rampT* rampT * rampT);
        float radius = ramp * Mathf.Sin(enabledTime * Mathf.PI * 0.5f);
	}
}
