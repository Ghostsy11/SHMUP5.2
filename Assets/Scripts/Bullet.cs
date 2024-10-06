using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    ParticlesVFX particlesVFX;
    AudioManager audioManager;
    private void Awake()
    {
        particlesVFX = FindObjectOfType<ParticlesVFX>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            audioManager.PlayRandomExplosionAudio();
            particlesVFX.PlayARandomParticleEffectAndAudioSFX(collision.transform);
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
    }
}
