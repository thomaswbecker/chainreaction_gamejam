using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosion : MonoBehaviour {
    public AudioClip[] barrelExplosionClips;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        playExplosionSound();
    }

    void Update()
    {
        if (!GetComponent<ParticleSystem>().IsAlive())
        {
            Destroy(this.gameObject);
        }
    }

    private void playExplosionSound()
    {
        if (barrelExplosionClips.Length > 0)
        {
            int index = Random.Range(0, barrelExplosionClips.Length);
            AudioClip chosenExplosion = barrelExplosionClips[index];
            audioSource.PlayOneShot(chosenExplosion);
        }
    }
}
