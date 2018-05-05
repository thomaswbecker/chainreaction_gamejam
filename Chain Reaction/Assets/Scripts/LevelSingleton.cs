using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// This is a monobehaviour to persist state across hot reloads
public class LevelSingleton : MonoBehaviour {
    public Transform GroundRotator;
    private void Awake()
    {
        GroundRotator = FindGroundTransform();
    }

    private static LevelSingleton s_instance;
    public static LevelSingleton Instance
    {
        get {
            if (!s_instance)
            {
                s_instance = new GameObject("Game Level State").AddComponent<LevelSingleton>();
            }
            return s_instance;
        }
    }


    static List<GameObject> rootGameObjects = new List<GameObject>(); // reusable buffer between frames
    private static Transform FindGroundTransform()
    {
        rootGameObjects.Clear();
        SceneManager.GetActiveScene().GetRootGameObjects(rootGameObjects);
        foreach (var go in rootGameObjects)
        {
            var rocker = go.GetComponent<BoatRocking>();
            if (rocker)
                return rocker.transform;
        }
        Debug.LogError("Level manager couldn't find the ground rotator.");
        // hook up a dummy object so we don't just crash.
        return new GameObject("Groundplane is missing").transform;
    }

}
