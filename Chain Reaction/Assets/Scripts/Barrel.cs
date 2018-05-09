using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Barrel : MonoBehaviour, IExplodeable
{
    [SerializeField] protected Transform CenterPoint;
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

    public Vector3 GetObjectCenter()
    {
        return CenterPoint.position;
    }
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
        int explosionBlockersLayer = 1 << LayerMask.NameToLayer("ExplosionBlockers"); // check only explosion blockers (walls etc.).  We don't want barrels to block other barrels.
        int explodeablesLayer = 1 << LayerMask.NameToLayer("Explodeables");
        var radius = GameSettings.Instance.ExplosionRadius;
        Vector3 myCenter = GetObjectCenter();
        var collisions = Physics.OverlapSphere(myCenter, radius, explodeablesLayer); // find all nearby barrels (only)
        
        foreach (Collider collision in collisions)
        {
            // If it's not something that can explode, we don't care.
            var explodeable = collision.GetComponent<IExplodeable>();
            if (explodeable == null)
                continue;

            
            // If there's a wall in the way, or if we're checking out ourselves, we also don't care.
            RaycastHit hit;
            Vector3 displacement = explodeable.GetObjectCenter() - myCenter;
            if (displacement.sqrMagnitude < 0.01f || Physics.Raycast(myCenter, displacement, out hit, displacement.magnitude, explosionBlockersLayer))
            {
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

    Vector3 IExplodeable.GetObjectCenter()
    {
        throw new System.NotImplementedException();
    }
}
