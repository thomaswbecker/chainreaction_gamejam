using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentDetonator : MonoBehaviour, IExplodeable
{
    [SerializeField] Transform ObjectCenterPoint;
    public float DetonatorDuration = 5f;
    private bool active = false;
    private SphereCollider sphere;

    // Use this for initialization
    void Start()
    {
        sphere = GetComponent<SphereCollider>();
        sphere.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Explode()
    {
        sphere.enabled = true;


    }
    void OnTriggerEnter(Collider other)
    {

        Debug.Log(other.name + "Just entered!");
        var explodable = other.GetComponent<IExplodeable>();
        if (explodable == null) return;
        explodable.Explode();

    }
    public Vector3 GetObjectCenter()
    {
        return ObjectCenterPoint != null ? ObjectCenterPoint.position : transform.position;
    }


}
