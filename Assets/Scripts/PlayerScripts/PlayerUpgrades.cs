using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] GameObject playerProjectilePrefab;
    [SerializeField] float prjectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    public float baseFiringRate = 0.2f;
    public float firingRateVariance = 0f;
    public float miniumFiringRate = 0.1f;
    public bool isFiring;

    [Header("Managing projectile speed buff")]
    [SerializeField] GameObject vitiltiyRenderer;
    [SerializeField] float timeHasPast;

    [Header("Managing projectile upgrade1 buff")]
    [SerializeField] GameObject playerProjectilePrefab1;
    public bool upgrade1IsBought;
    [SerializeField] Transform upgrade1Transform;
    [SerializeField] Vector2 vector2Upgrade1;

    [Header("Managing projectile upgrade1 buff")]
    [SerializeField] GameObject playerProjectilePrefab2;
    public bool upgrade2IsBought;
    [SerializeField] Transform upgrade2Transform;
    [SerializeField] Vector2 vector2Upgrade2;

    AudioManager audioManager;
    ParticlesVFX particlesVFX;
    Coroutine firingCoroutine;

    [Header("Location to play VFX effect")]
    [SerializeField] Transform Vaitlitylocation;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        particlesVFX = FindObjectOfType<ParticlesVFX>();

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
            Upgrade1();
            Upgrade2();
            //Upgrade3();
            //Upgrade4();
            Destroy(istance, projectileLifeTime);

            float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);

            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, miniumFiringRate, float.MaxValue);

            yield return new WaitForSeconds(timeToNextProjectile);

        }
    }


    public IEnumerator TimeBuffManager()
    {
        baseFiringRate = 0.11f;
        miniumFiringRate = 0f;
        firingRateVariance = 0f;
        vitiltiyRenderer.SetActive(true);

        Vaitlitylocation.transform.position = new Vector3(0, 9, 0);
        audioManager.OnPickUpV();
        particlesVFX.VatilityEffect(Vaitlitylocation);
        yield return new WaitForSeconds(timeHasPast);

        vitiltiyRenderer.SetActive(false);
        baseFiringRate = 0.2f;
        miniumFiringRate = 0.2f;
        firingRateVariance = 0.1f;
        StopCoroutine(TimeBuffManager());

    }


    //Upgrades

    private void Upgrade1()
    {
        if (upgrade1IsBought)
        {


            GameObject istance1 = Instantiate(playerProjectilePrefab1, upgrade1Transform.transform.position, Quaternion.identity);

            Rigidbody2D rb1 = istance1.GetComponent<Rigidbody2D>();
            if (istance1 != null)
            {
                rb1.velocity = (vector2Upgrade1 * prjectileSpeed);
            }
            Destroy(istance1, projectileLifeTime);
        }
        else
        {
            return;
        }
    }

    private void Upgrade2()
    {
        if (upgrade2IsBought)
        {
            GameObject istance1 = Instantiate(playerProjectilePrefab2, upgrade2Transform.transform.position, Quaternion.identity);

            Rigidbody2D rb1 = istance1.GetComponent<Rigidbody2D>();
            if (istance1 != null)
            {
                rb1.velocity = (vector2Upgrade2 * prjectileSpeed);
            }
            Destroy(istance1, projectileLifeTime);
        }
        else
        {
            return;
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
