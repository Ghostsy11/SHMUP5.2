using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("Player Shooting Clip")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField][Range(0f, 1f)] float shootingVolume = 1f;


    [Header("Enemy Or Player Shooting Clip")]
    [SerializeField] AudioClip shootingClipType2;
    [SerializeField][Range(0f, 1f)] float shootingVolumE = 1f;


    [Header("Random Explosion Audio Effect")]
    [SerializeField] AudioClip[] explosionType1;
    [SerializeField][Range(0f, 1f)] float explosionVolumE1 = 1f;

    [Header("When Enemy Die Play this SFX")]
    [SerializeField] AudioClip explosionType2;
    [SerializeField][Range(0f, 1f)] float explosionVolumE2 = 1f;

    [Header("When Player Die Play this SFX")]
    [SerializeField] AudioClip explosionType3;
    [SerializeField][Range(0f, 1f)] float explosionVolumE3 = 1f;

    [Header("When Player Active KillAllEnemySkill SFX")]
    [SerializeField] AudioClip explosionType4;
    [SerializeField][Range(0f, 1f)] float explosionVolumE4 = 1f;

    [Header("Shield Up SFX")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip shieldUpAudio;
    [SerializeField][Range(0f, 1f)] float shieldUpAudiopVolum = 1f;

    [Header("Vatility PickUp SFX")]
    [SerializeField] AudioClip pickUpAudioSort1;
    [SerializeField][Range(0f, 1f)] float pickUpVolumP1 = 1f;


    [Header("Vatility HealUp SFX")]
    [SerializeField] AudioClip pickUpAudioSort2;
    [SerializeField][Range(0f, 1f)] float pickUpVolumP2 = 1f;

    [Header("Vatility Upgrade SFX")]
    [SerializeField] AudioClip pickUpAudioSort3;
    [SerializeField][Range(0f, 1f)] float pickUpVolumP3 = 1f;

    [Header("Projectile Upgrade SFX")]
    [SerializeField] AudioClip pickUpAudioSort4;
    [SerializeField][Range(0f, 1f)] float pickUpVolumP4 = 1f;

    static AudioManager instance;

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

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void OnEnemyDeathSFX()
    {
        PlayClip(explosionType2, explosionVolumE2);
    }

    public void OnPlayDeathSFX()
    {
        PlayClip(explosionType3, explosionVolumE3);
    }

    public void OnKillAllSkillActivitet()
    {
        PlayClip(explosionType4, explosionVolumE4);
    }

    public void OnPickUpV()
    {
        PlayClip(pickUpAudioSort1, pickUpVolumP1);
    }

    public void OnHealUpH()
    {
        PlayClip(pickUpAudioSort2, pickUpVolumP2);
    }

    public void OnUpgradeUp()
    {
        PlayClip(pickUpAudioSort3, pickUpVolumP3);
    }

    public void OnProjectileUpgradeUp()
    {
        PlayClip(pickUpAudioSort4, pickUpVolumP4);
    }

    public void ShieldUp()
    {
        if (!audioSource.isPlaying)
        {

            audioSource.PlayOneShot(shieldUpAudio);
        }
    }

    private void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }

    public void PlayRandomExplosionAudio()
    {
        if (explosionType1 != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            var radomAudio = Random.Range(0, explosionType1.Length);
            AudioSource.PlayClipAtPoint(explosionType1[radomAudio], cameraPos, explosionVolumE1);
        }
    }

}
