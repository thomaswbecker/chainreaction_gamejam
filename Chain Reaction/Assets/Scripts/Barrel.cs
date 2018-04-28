using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Barrel : MonoBehaviour {

    public BarrelExplosion ExplosionPrefab;

	// Use this for initialization
	void Start() {
	}
	
	// Update is called once per frame
	void Update() {
		
	}
    [HideInInspector]
    public bool alive = true;
    public bool hasDetonator = false;
    void Explode() {
        if (!alive)
            return;
        alive = false;

        var radius = GameSettings.Instance.ExplosionRadius;
        var collisions = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collision in collisions)
        {
            var barrel = collision.gameObject.GetComponent<Barrel>();
            if (!barrel)
                continue;

            barrel.Explode();
        }

        GameObject.Instantiate(ExplosionPrefab.gameObject, gameObject.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
    void OnMouseOver()
    {
        if (!hasDetonator)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            Explode();
            // Whatever you want it to do.
        }
    }
}
