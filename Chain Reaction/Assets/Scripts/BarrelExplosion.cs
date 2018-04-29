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

    // Use this for initialization
    void Start () {	
	}

    // Update is called once per frame
    void Update()
    {

    }

    private void playExplosionSound()
    {
        if (barrelExplosionClips.Length > 0)
        {
            int index = Random.Range(0, barrelExplosionClips.Length);
            Debug.Log("playing sound number " + index);
            AudioClip chosenExplosion = barrelExplosionClips[index];
            audioSource.PlayOneShot(chosenExplosion);
        }
    }
}
