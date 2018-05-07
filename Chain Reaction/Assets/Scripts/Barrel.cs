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
    GameObject createCountdownText(float countdownTime)
    {
        var go = GameObject.Instantiate(GameSettings.Instance.ExplosionCountdownPrefab);
        var timerObject = go.GetComponent<ExplosionTimerText>();
        timerObject.StartCountdown(countdownTime);
        return go;
    }
    IEnumerator ExplosionSequence()
    {
        var countdownTime = GetExplosionDelayTime();
        // show countdown for non trivial explosion timings
        if (countdownTime >= GameSettings.Instance.MinDelayForCountdownPopup)
        {
            createCountdownText(countdownTime).transform.SetParent(transform, false);
        }

        yield return new WaitForSeconds(countdownTime);

        var radius = GameSettings.Instance.ExplosionRadius;
        var collisions = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collision in collisions)
        {
            Debug.Log(collisions.Length + " colliders found");
            // If it's not something that can explode, we don't care.
            var explodeable = collision.GetComponent<IExplodeable>();
            if (explodeable == null)
                continue;

            int layerMask = LayerMask.NameToLayer("ExplosionBlockers"); // check only explosion blockers (walls etc.).  We don't want barrels to block other barrels.
            // If there's a wall in the way, we also don't care.
            RaycastHit hit;
            if (Physics.Raycast(transform.position, (collision.transform.position - transform.position), out hit, 10f))
            {
              
                    if(!collision.transform.IsChildOf(hit.transform))
                    continue;
                
            }
            
            explodeable.Explode();
        }
        if (ExplosionPrefab != null)
        {
            GameObject.Instantiate(ExplosionPrefab.gameObject, gameObject.transform.position, Quaternion.identity);
        }

        Destroy(this.gameObject);
    }

}
