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
            GameObject instance = GameObject.Instantiate(RadiusIndicatorPrefab, transform.parent.GetComponent<LevelManager>().Groundplane);
            widgetInstance = instance.GetComponent<ExplosionIndicatorWidget>();
            widgetInstance.TrackedDetonator = this;
        }
    }
    void OnMouseExit()
    {
        if (widgetInstance && widgetInstance.gameObject)
            Destroy(widgetInstance.gameObject);
    }
}
