using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour, IExplodeable
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDestroy()
    {
        
        
    }

    public void Explode()
    {
        Destroy(gameObject);
        Debug.Log("Ouch! I've been killed by a cleverly executed sequence of events!");
    }
}
