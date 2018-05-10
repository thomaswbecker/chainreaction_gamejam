using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour, IExplodeable
{
    [SerializeField] Transform ObjectCenter;
    // Use this for initialization
    void Start()
    {
        Debug.Assert(ObjectCenter != null);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDestroy()
    {
        
        
    }

    public void Explode(Vector3 force, float additionalDelay)
    {
        
        Debug.Log("Ouch! I've been killed by a cleverly executed sequence of events!");
        Destroy(gameObject);
    }
    public Vector3 GetObjectCenter()
    {
        return ObjectCenter != null ? ObjectCenter.position : transform.position;
    }
}
