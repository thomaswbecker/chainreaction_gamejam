
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
        Debug.Log("Pirate " + this.GetHashCode() + " has been eliminated!");
    }
}

