using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
class Pirate : MonoBehaviour, IExplodeable
{
    [SerializeField] Transform ObjectCenter;
    bool isAlive = true;
    void Start()
    {

    }
    public void Explode(Vector3 force, float additionalDelay)
    {
        if (isAlive)
        {
            float strength = 10f;
            GetComponent<Rigidbody>().AddExplosionForce(strength, transform.position - force.normalized, 1000f, 1f, ForceMode.Impulse);
            StartCoroutine(DoDisappearingAct());
            isAlive = false;
            tag = "Dead Enemy";
            Debug.Log("Pirate " + this.GetHashCode() + " has been eliminated!");
        }

    }

    IEnumerator DoDisappearingAct()
    {
        yield return new WaitForSeconds(GameSettings.Instance.PirateDisappearanceDelay);
        gameObject.AddComponent<PirateDisappearingEffect>();
        yield return null;
    }
    public Vector3 GetObjectCenter()
    {
        return ObjectCenter != null ? ObjectCenter.position : transform.position;
    }
}

