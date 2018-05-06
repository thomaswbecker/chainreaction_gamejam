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
