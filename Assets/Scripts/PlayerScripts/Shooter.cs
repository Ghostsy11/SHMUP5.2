using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] GameObject playerProjectilePrefab;
    [SerializeField] float prjectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    public float baseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] bool useAI;
    public float firingRateVariance = 0f;
    public float miniumFiringRate = 0.1f;
    public bool isFiring;

    [Header("Managing Enemy Difficilty")]
    [SerializeField] float timeHasCollapsed;
    [SerializeField] float increaseDifficlity;
    [SerializeField] float time;

    AudioManager audioManager;

    Coroutine firingCoroutine;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

    }

    void Update()
    {
        if (useAI)
        {
            isFiring = true;
        }
        IncraseDifficlity();

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

    private void IncraseDifficlity()
    {
        if (gameObject.tag == "Enemy")
        {
            time = Time.time;
            timeHasCollapsed += Time.deltaTime;
            if (timeHasCollapsed >= increaseDifficlity)
            {
                if (miniumFiringRate != 0 && firingRateVariance != 0 && miniumFiringRate >= -0.1 && firingRateVariance >= -0.1)
                {
                    miniumFiringRate -= 0.2f;
                    firingRateVariance -= 0.2f;
                    // to incrase damage too
                    DamageDealer damageDealer = GetComponent<DamageDealer>();
                    damageDealer.IncreaseDamage();
                    timeHasCollapsed = 0;
                }
                else
                {
                    miniumFiringRate = 0;
                    firingRateVariance = 0;
                    return;
                }

            }
        }

    }




    private void Upgrade3()
    {
        GameObject istance2 = Instantiate(playerProjectilePrefab, transform.position, Quaternion.AngleAxis(50, new Vector3(0, 0, 1)));

        Rigidbody2D rb2 = istance2.GetComponent<Rigidbody2D>();
        if (istance2 != null)
        {
            rb2.velocity = (new Vector3(-1f, 0.5f, 0f) * prjectileSpeed);
        }
        Destroy(istance2, projectileLifeTime);

    }


    private void Upgrade4()
    {
        GameObject istance1 = Instantiate(playerProjectilePrefab, transform.position, Quaternion.AngleAxis(50, new Vector3(0, 0, -1)));

        Rigidbody2D rb1 = istance1.GetComponent<Rigidbody2D>();
        if (istance1 != null)
        {
            rb1.velocity = (new Vector3(1f, 0.5f, 0f) * prjectileSpeed);
        }
        Destroy(istance1, projectileLifeTime);

    }
}
