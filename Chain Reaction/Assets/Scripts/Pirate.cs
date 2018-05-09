
using UnityEngine;
class Pirate : MonoBehaviour, IExplodeable
{
    [SerializeField] Transform ObjectCenter;
    bool isAlive = true;
    void Start()
    {

    }
    public void Explode()
    {
        isAlive = false;
        tag = "Dead Enemy";
        Debug.Log("Pirate " + this.GetHashCode() + " has been eliminated!");
    }
    public Vector3 GetObjectCenter()
    {
        return ObjectCenter != null ? ObjectCenter.position : transform.position;
    }
}

