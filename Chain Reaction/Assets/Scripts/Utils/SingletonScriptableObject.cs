using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
