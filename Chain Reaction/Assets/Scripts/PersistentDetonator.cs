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
    public void Explode(Vector3 force, float additionalDelay)
    {
        sphere.enabled = true;


    }
    void OnTriggerEnter(Collider other)
    {

        Debug.Log(other.name + "Just entered!");
        var explodable = other.GetComponent<IExplodeable>();
        if (explodable == null) return;
        Vector3 vec = other.transform.position - transform.position;
        explodable.Explode(ExplosionUtils.ExplosiveForce(vec, vec.magnitude, GameSettings.Instance.ExplosionRadius));
    }
    public Vector3 GetObjectCenter()
    {
        return ObjectCenterPoint != null ? ObjectCenterPoint.position : transform.position;
    }


}
