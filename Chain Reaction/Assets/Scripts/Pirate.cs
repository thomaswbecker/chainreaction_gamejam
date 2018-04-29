
using UnityEngine;
class Pirate : MonoBehaviour, IExplodeable
{
    bool isAlive = true;
    void Start()
    {

    }
    public void Explode()
    {
        Debug.Log("Pirate " + this.GetHashCode() + " has been eliminated!");
    }
}

