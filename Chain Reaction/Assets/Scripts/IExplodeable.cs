using UnityEngine;

public interface IExplodeable
{
    void Explode(Vector3 force, float additionalDelay = 0f);
    Vector3 GetObjectCenter();
}

public abstract class ExplosionUtils
{
    public static Vector3 ExplosiveForce(Vector3 provokerToTarget, float distanceToTarget, float explosionRadius)
    {
        const float strength = 1f; // maybe this should be a knob.
        float falloffRatio = (explosionRadius - distanceToTarget) / explosionRadius;
        float falloffFactor = Mathf.Pow(falloffRatio, 1.5f);
        return provokerToTarget * (strength / (distanceToTarget * falloffFactor));
    }
}