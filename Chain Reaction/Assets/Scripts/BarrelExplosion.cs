using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosion : MonoBehaviour {
    public AudioClip[] barrelExplosionClips;

    private AudioSource audioSource;
    private List<ParticleSystem> particles = new List<ParticleSystem>();
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        playExplosionSound();
    }

    void Update()
    {
        var localps = GetComponent<ParticleSystem>();
        if (localps)
            particles.Add(localps);
        else
            GetComponentsInChildren(particles);

        if (particles.TrueForAll(ps => !ps.IsAlive()))
            Destroy(this.gameObject);
        particles.Clear();
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
