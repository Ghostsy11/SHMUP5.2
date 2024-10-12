using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUp : MonoBehaviour
{
    [SerializeField] float timeToLoadTheSkill;
    [SerializeField] float timeRightNow;

    public bool readyToShieldUp;

    [SerializeField] float timeToPlayTheSkillSFX;
    [SerializeField] float timeRightNowForSFX;


    [SerializeField] GameObject iconWhenShieldReady;
    [SerializeField] GameObject iconReadyState;

    [SerializeField] AudioSource shieldTimer;
    AudioManager audioManager;

    BoxCollider2D boxCollider;



    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = true;
        iconReadyState.SetActive(false);
    }
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void Update()
    {
        PlayShiedUpStateReadySFX();
        LoadingTheSkill();

    }

    private void LoadingTheSkill()
    {
        timeRightNow += Time.deltaTime;
        if (timeRightNow >= timeToLoadTheSkill)
        {
            readyToShieldUp = true;
            iconReadyState.SetActive(true);

        }
    }


    private void PlayShiedUpStateReadySFX()
    {
        timeRightNowForSFX += Time.deltaTime;
        if (timeRightNowForSFX >= timeToPlayTheSkillSFX)
        {
            audioManager.ShieldUp();
            timeRightNowForSFX = 0;
        }
    }


    public IEnumerator ActivatietShieldSkill()
    {
        if (readyToShieldUp)
        {

            readyToShieldUp = false;
            timeRightNow = 0;
            iconReadyState.SetActive(false);
            boxCollider.enabled = false;
            iconWhenShieldReady.SetActive(true);
            shieldTimer.Play();
            yield return new WaitForSeconds(18f);
            shieldTimer.Stop();
            iconWhenShieldReady.SetActive(false);
            boxCollider.enabled = true;
            StopCoroutine(ActivatietShieldSkill());
        }

    }
}
