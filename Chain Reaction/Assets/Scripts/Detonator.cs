using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IExplodeable))]
public class Detonator : MonoBehaviour
{
    ExplosionIndicatorWidget widgetInstance;

    public Camera gameCamera;
    public bool CameraFollow = true;


    private void Start()
    {
        gameCamera = Camera.main;
        Debug.Log(transform.GetChild(1).name);
    }


    private void Update()
    {
        if (CameraFollow)
        {
            gameCamera.transform.LookAt(gameObject.transform);
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        transform.Rotate(0, x, 0, Space.World);


    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody>().AddForce(-transform.right * 100, ForceMode.Acceleration);
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
