using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IExplodeable))]
public class Detonator : MonoBehaviour {
    ExplosionIndicatorWidget widgetInstance;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<IExplodeable>().Explode(Vector3.zero, additionalDelay: GameSettings.Instance.BarrelClickDelay);
        }
    }
    void OnMouseEnter()
    {
        if (GameSettings.Instance.RadiusIndicatorPrefab)
        {
            GameObject instance = GameObject.Instantiate(GameSettings.Instance.RadiusIndicatorPrefab, LevelSingleton.Instance.GroundRotator);
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
