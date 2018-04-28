using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
{
    static T _instance = null;
    public static T Instance
    {
        get
        {
            if (!_instance)
            {
                var settings = Resources.LoadAll<T>("");
                _instance = settings[0];
            }
            return _instance;
        }
    }
}


[CreateAssetMenu(fileName = "GameSettings", menuName = "Game Settings File", order = 1)]
public class GameSettings : ScriptableObject {
    
    public float ExplosionRadius = 1.0f;
    public float BarrelClickDelay = 1.0f;
    public float ChainExplosionDelay = 0.3f;
    public static GameSettings Instance
    {
        get { return SingletonScriptableObject<GameSettings>.Instance; }
    }
}
