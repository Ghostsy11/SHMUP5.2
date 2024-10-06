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

    [Header("-")]
    [SerializeField] AudioClip explosionType4;
    [SerializeField][Range(0f, 1f)] float explosionVolumE4 = 1f;

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
