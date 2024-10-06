using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] GameObject playerProjectilePrefab;
    [SerializeField] float prjectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float miniumFiringRate = 0.1f;
    public bool isFiring;

    AudioManager audioManager;

    Coroutine firingCoroutine;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        if (useAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {

            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    private IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject istance = Instantiate(playerProjectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = istance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = (transform.up * prjectileSpeed);
                audioManager.PlayShootingClip();

            }
            Destroy(istance, projectileLifeTime);

            float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);

            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, miniumFiringRate, float.MaxValue);

            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }

    //Upgrades
    private void Upgrade()
    {
        GameObject istance1 = Instantiate(playerProjectilePrefab, transform.position, Quaternion.AngleAxis(50, new Vector3(0, 0, -1)));

        Rigidbody2D rb1 = istance1.GetComponent<Rigidbody2D>();
        if (istance1 != null)
        {
            rb1.velocity = (new Vector3(1f, 0.5f, 0f) * prjectileSpeed);
        }

    }

    private void Upgrade2()
    {
        GameObject istance2 = Instantiate(playerProjectilePrefab, transform.position, Quaternion.AngleAxis(50, new Vector3(0, 0, 1)));

        Rigidbody2D rb2 = istance2.GetComponent<Rigidbody2D>();
        if (istance2 != null)
        {
            rb2.velocity = (new Vector3(-1f, 0.5f, 0f) * prjectileSpeed);
        }

    }
}
