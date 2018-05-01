using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Material))]
public class ExplosionIndicatorWidget : MonoBehaviour {
    float enableTime;

    public float Thickness = 5;

    public MeshRenderer MeshRendererInstance;
    public Detonator TrackedDetonator;
    private void OnEnable()
    {
        enableTime = Time.time;
        MeshRendererInstance.enabled = true;
    }
    private void OnDisable()
    {
        MeshRendererInstance.enabled = false;
    }

    // Our parent must be the ground plane.
    Transform GetGroundTransform()
    {
        return transform.parent;
    }
    void SnapToGround()
    {
        const float heightoffset = 0.01f; // prevent z-fighting
        Vector3 groundRelativePos = GetGroundTransform().worldToLocalMatrix * TrackedDetonator.transform.position;
        groundRelativePos.y = heightoffset;
        transform.localPosition = groundRelativePos;
    }
    // Update is called once per frame
    void Update () {
        if (!TrackedDetonator)
        {
            Destroy(this.gameObject);
            return;
        }
        float enabledTime = Time.time - enableTime;
        const float rampTime = 0.3f;
        float rampT = 1 / rampTime ;
        float startRamp = Mathf.Clamp01(rampT* rampT * enabledTime) ;

        const float wobblescale = 0.1f; // relative to the size of the quad
        const float scalemax = 0.9f; // how close to the edge we want to render.  higher values are more efficient, but may clip if thickness is too high
        const float freq = 2f; // pulses per second

        float quadSpaceRadius = scalemax;
        MeshRendererInstance.sharedMaterial.SetFloat("_Radius", quadSpaceRadius);

        float wobble = (startRamp + (Mathf.Sin(enabledTime * Mathf.PI * 2f * freq) * wobblescale * 0.5f) - wobblescale * 0.5f);
        float objScale = GameSettings.Instance.ExplosionRadius * (1f / scalemax) * wobble;
        transform.localScale = new Vector3(objScale, objScale, objScale);

        MeshRendererInstance.sharedMaterial.SetFloat("_Thickness", Thickness/objScale);


        SnapToGround();
	}
}
