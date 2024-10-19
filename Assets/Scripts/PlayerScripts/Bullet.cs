using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    ParticlesVFX particlesVFX;
    AudioManager audioManager;
    public bool activitied;
    private void Awake()
    {
        particlesVFX = FindObjectOfType<ParticlesVFX>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && activitied == true)
        {
            audioManager.PlayRandomExplosionAudio();
            particlesVFX.PlayARandomParticleEffect(collision.transform);
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
    }
}
