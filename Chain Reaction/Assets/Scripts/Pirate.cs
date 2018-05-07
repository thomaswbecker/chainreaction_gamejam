
using UnityEngine;
class Pirate : MonoBehaviour, IExplodeable
{
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
}

