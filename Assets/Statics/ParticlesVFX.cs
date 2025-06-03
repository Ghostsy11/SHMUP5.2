using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesVFX : MonoBehaviour
{
    [Header("Player Or Enemy Hitting EachOther")]
    [SerializeField] ParticleSystem particle1;

    [Header("On Enemy Death")]
    [SerializeField] ParticleSystem particle2;

    [Header("On Player Death")]
    [SerializeField] ParticleSystem particle3;

    [Header("MegaExplosive")]
    [SerializeField] ParticleSystem particle4;

    [Header("Vaitilty Effect")]
    [SerializeField] ParticleSystem particle5;

    [Header("Random VFX When Bullet hit each other")]
    [SerializeField] ParticleSystem[] particles;

    [Header("Refrences")]
    static ParticlesVFX instance;

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayOnHittingEnemy(Transform location)
    {
        PlayPartilceEffect(particle1, location.gameObject.transform);
    }

    public void OnEnemyDeathVFX(Transform location)
    {
        PlayPartilceEffect(particle2, location.gameObject.transform);
    }

    public void OnPlayerDeathVFX(Transform location)
    {
        PlayPartilceEffect(particle3, location.gameObject.transform);
    }

    public void KillAllEnemyExplosivs(Transform location)
    {
        PlayPartilceEffect(particle4, location.gameObject.transform);
    }

    public void VatilityEffect(Transform location)
    {
        PlayPartilceEffect(particle5, location.gameObject.transform);
    }
    private void PlayPartilceEffect(ParticleSystem particle, Transform pos)
    {
        if (particle != null)
        {
            ParticleSystem VFX = Instantiate(particle, pos.gameObject.transform.position, Quaternion.identity);
            Destroy(VFX.gameObject, VFX.main.duration + VFX.main.startLifetime.constantMax);
        }
    }
    public void PlayARandomParticleEffect(Transform pos)
    {
        if (particles != null)
        {
            var randomParticle = Random.Range(0, particles.Length);
            var par = Instantiate(particles[randomParticle], pos.transform.position, Quaternion.identity);
            par.Play();
            Destroy(par, 5);

        }
    }
}
