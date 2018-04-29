using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IExplodeable))]
public class Detonator : MonoBehaviour {
    public GameObject RadiusIndicatorPrefab;
    ExplosionIndicatorWidget widgetInstance;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(MouseClickDelay(GameSettings.Instance.BarrelClickDelay));
        }
    }
    IEnumerator MouseClickDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        GetComponent<IExplodeable>().Explode();
    }
    void OnMouseEnter()
    {
        if (RadiusIndicatorPrefab)
        {
            GameObject instance = GameObject.Instantiate(RadiusIndicatorPrefab, transform);
            Debug.Log("Spawning " + instance);
            widgetInstance = instance.GetComponent<ExplosionIndicatorWidget>();
            widgetInstance.enabled = true;
        }
    }
    void OnMouseExit()
    {
        Destroy(widgetInstance.gameObject);
    }
}
