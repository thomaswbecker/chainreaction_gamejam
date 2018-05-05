using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



[CreateAssetMenu(fileName = "GameSettings", menuName = "Game Settings File", order = 1)]
public class GameSettings : ScriptableObject {
    
    public float ExplosionRadius = 1.0f;
    public float BarrelClickDelay = 1.0f;
    public float ChainExplosionDelay = 0.3f;
    public GameObject RadiusIndicatorPrefab;
    public static GameSettings Instance
    {
        get { return SingletonScriptableObject<GameSettings>.Instance; }
    }
}
