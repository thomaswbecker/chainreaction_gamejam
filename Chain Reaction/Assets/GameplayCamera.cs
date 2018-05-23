using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayCamera : MonoBehaviour {

    public float explosionShakeTime = 0.5f;
    public float explosionShakeMagnitude = 1f;
    public AnimationCurve explosionShakeCurve;

    private bool initialized = false;

    void InitializeIfNeeded()
    {
        if (!initialized)
        {
            transform.localPosition = Vector3.zero;
            LevelSingleton.Instance.OnBarrelExplosion.AddListener(OnBarrelExplosion);
        }
    }

    float shakeStartTime = 0f;
    bool shaking = false;
    float barrelDistance;
    private void OnBarrelExplosion(Vector3 barrelPosition)
    {
        shakeStartTime = Time.time;
        barrelDistance = (transform.position - barrelPosition).magnitude;
        shaking = true;
    }
    private void Update()
    {
        InitializeIfNeeded();
        if (shaking)
        {
            float rawT = (Time.time - shakeStartTime) / explosionShakeTime;
            float t = Mathf.Clamp01(rawT);
            float distanceT = Mathf.Clamp01(Mathf.InverseLerp(15, 25, barrelDistance));
            float distanceBasedScale = Mathf.Lerp(0.5f, 1, 1 - distanceT);
            transform.localPosition = Random.insideUnitSphere * (explosionShakeCurve.Evaluate(t) * explosionShakeMagnitude * distanceBasedScale);
            if (rawT >= 1f)
            {
                shaking = false;
                transform.localPosition = Vector3.zero;
            }       
        }
    }
}
