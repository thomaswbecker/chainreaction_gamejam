using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Barrel : MonoBehaviour, IExplodeable 
{
    public int ChainExplosionDelayTimeIndex = 0;
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

    float GetExplosionDelayTime()
    {
        var numTimes = GameSettings.Instance.ChainExplosionDelayTimes.Length;
        if (ChainExplosionDelayTimeIndex >= numTimes)
        {
            Debug.LogError("ChainExplosionDelayTimeIndex out of range: " + ChainExplosionDelayTimeIndex);
            return 0f;
        }
        return GameSettings.Instance.ChainExplosionDelayTimes[ChainExplosionDelayTimeIndex];
    }
    IEnumerator ExplosionSequence()
    {
        yield return new WaitForSeconds(GetExplosionDelayTime());
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
