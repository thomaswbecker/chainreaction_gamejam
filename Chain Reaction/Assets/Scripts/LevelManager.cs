using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public Transform Groundplane;
    private void Start()
    {
        if (!Groundplane)
        {
            Debug.LogWarning("Level manager is missing ground plane reference.");
            // hook up a dummy object so we don't just crash.
            Groundplane = new GameObject("Groundplane is missing").transform;
            Groundplane.parent = transform;
        }
    }
}
