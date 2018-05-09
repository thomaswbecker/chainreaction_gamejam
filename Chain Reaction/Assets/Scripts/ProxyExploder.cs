using UnityEngine;

// This class exists because due to our meshes being scaled, our collider is not on the same object as our explode script.
public class ProxyExploder : MonoBehaviour, IExplodeable
{
    public Barrel RealExplodeable;
    public void Explode()
    {
        RealExplodeable.Explode();
    }
    public Vector3 GetObjectCenter()
    {
        return RealExplodeable.GetObjectCenter();
    }
}
