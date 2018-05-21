using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pirate))]
public class PirateDisappearingEffect : MonoBehaviour {
    private void Awake()
    {
        if (GameSettings.Instance.PirateDisappearanceEffectPrefab)
        {
            GameObject.Instantiate(GameSettings.Instance.PirateDisappearanceEffectPrefab,
                GetComponent<Pirate>().GetObjectCenter(), Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
