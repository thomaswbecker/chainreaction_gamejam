using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Barrel : MonoBehaviour, IExplodeable 
{

    public BarrelExplosion ExplosionPrefab;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    [HideInInspector]
    public bool alive = true;

    public void Explode()
    {
        if (!alive)
            return;
        alive = false;
        StartCoroutine(ExplosionSequence());
    }

    IEnumerator ExplosionSequence()
    {
        yield return new WaitForSeconds(GameSettings.Instance.ChainExplosionDelay);
        var radius = GameSettings.Instance.ExplosionRadius;
        var collisions = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collision in collisions)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, (collision.transform.position - transform.position), out hit, 10f) )
            {
                if (hit.transform == collision.transform)
                {

                    var barrel = collision.gameObject.GetComponent<IExplodeable>();
                    if (barrel != null)
                        barrel.Explode();
                }
            }
        }
        if (ExplosionPrefab != null)
        {
            GameObject.Instantiate(ExplosionPrefab.gameObject, gameObject.transform.position, Quaternion.identity);
        }

        Destroy(this.gameObject);
    }

}
