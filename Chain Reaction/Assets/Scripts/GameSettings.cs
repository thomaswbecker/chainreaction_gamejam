using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



[CreateAssetMenu(fileName = "GameSettings", menuName = "Game Settings File", order = 1)]
public class GameSettings : ScriptableObject {
    
    public float ExplosionRadius = 1.0f;
    public float BarrelClickDelay = 1.0f;
    public float [] ChainExplosionDelayTimes;
    public float MinDelayForCountdownPopup = 0.4f;
    public GameObject RadiusIndicatorPrefab;
    public GameObject ExplosionCountdownPrefab;
    public static GameSettings Instance
    {
        get { return SingletonScriptableObject<GameSettings>.Instance; }
    }
}
