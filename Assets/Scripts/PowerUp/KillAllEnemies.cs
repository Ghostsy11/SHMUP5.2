using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAllEnemies : MonoBehaviour
{

    [SerializeField] float timeToLoadTheSkill;
    [SerializeField] float timeRightNow;
    public bool readyToKillAll;
    [SerializeField] GameObject iconWhenSkillIsReady;
    AudioManager audioManager;
    ParticlesVFX particlesVFX;
    BoxCollider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;
    }

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        particlesVFX = FindObjectOfType<ParticlesVFX>();
    }

    private void Update()
    {
        LoadingTheSkill();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }


    private void LoadingTheSkill()
    {
        timeRightNow += Time.deltaTime;
        if (timeRightNow >= timeToLoadTheSkill)
        {
            iconWhenSkillIsReady.SetActive(true);
            readyToKillAll = true;
        }
    }

    public IEnumerator ActivatietSkill()
    {
        if (readyToKillAll)
        {
            boxCollider.enabled = true;
            timeRightNow = 0;
            iconWhenSkillIsReady.SetActive(false);
            readyToKillAll = false;
            audioManager.OnKillAllSkillActivitet();
            particlesVFX.KillAllEnemyExplosivs(gameObject.transform);
            yield return new WaitForSeconds(1.2f);
            boxCollider.enabled = false;
            StopCoroutine(ActivatietSkill());
        }

    }

}
