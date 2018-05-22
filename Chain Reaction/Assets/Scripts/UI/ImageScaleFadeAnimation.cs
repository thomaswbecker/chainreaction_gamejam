using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class ImageScaleFadeAnimation : MonoBehaviour {
    [Range(0, 10)]
    public float effectDuration = 1f;
    public AnimationCurve alphaOverTime;
    public AnimationCurve scaleOverTime;

    float startTime;
    private void Awake()
    {
        GetComponent<RawImage>().color = new Color(1f, 1f, 1f, alphaOverTime.Evaluate(0f));
    }
    private void OnEnable()
    {
        startTime = Time.realtimeSinceStartup;
        gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        float rawT = effectDuration * (Time.realtimeSinceStartup - startTime);
        float t = Mathf.Clamp01(rawT);

        // fade
        float alpha = alphaOverTime.Evaluate(t);
        GetComponent<RawImage>().color = new Color(1f, 1f, 1f, alpha);
        // size
        float scale = scaleOverTime.Evaluate(t);
        transform.localScale = new Vector3(scale, scale, scale);

        // stop when done
        if (rawT >= 1f)
            enabled = false;
    }
}
