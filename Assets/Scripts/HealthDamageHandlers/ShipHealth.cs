using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ShipHealth : MonoBehaviour
{
    [Header("General Settings")]

    [Tooltip("Heath per ship that is (ShipHealth script) attachted to it")]
    public int health = 120;

    [Tooltip("Given score when you kill a enemy")]
    [SerializeField] int OnEnemyDeathAddScore = 10;

    [Tooltip("Amount of gold you earn when you kill enemy")]
    [SerializeField] int earnGold = 1;

    [Header("Refrences")]
    [Tooltip("Refrences that are manages via code")]
    [SerializeField] ParticlesVFX particlesVFX;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] AudioManager audioManager;
    [SerializeField] SpriteRenderer playerSpriteRenderer;
    [SerializeField] BoxCollider2D playerBoxCollider2D;

    [Header("Player Health Status after upgrade")]
    [SerializeField] GameObject heartOne;
    [SerializeField] GameObject heartTwo;
    [SerializeField] GameObject heartThree;
    [SerializeField] GameObject heartFour;

    [Header("Main Health")]
    [SerializeField] GameObject heartOne1;
    [SerializeField] GameObject heartTwo2;
    [SerializeField] GameObject heartThree3;
    private void Awake()
    {
        particlesVFX = FindObjectOfType<ParticlesVFX>();
        scoreManager = FindObjectOfType<ScoreManager>();
        audioManager = FindObjectOfType<AudioManager>();

    }

    private void Update()
    {
        PlayerNormalHealth();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            particlesVFX.PlayOnHittingEnemy(gameObject.transform);
            damageDealer.Hit();
        }
    }


    public void TakeDamage(int Damage)
    {
        health -= Damage;

        if (health <= 0 && gameObject.tag == "Enemy")
        {
            scoreManager.ModifyScore(OnEnemyDeathAddScore);
            scoreManager.AddGold(earnGold);

            audioManager.OnEnemyDeathSFX();
            particlesVFX.OnEnemyDeathVFX(gameObject.transform);


            Destroy(gameObject, 0.01f);
        }
        else if (health <= 0 && gameObject.tag == "Player")
        {
            PlayerInput playerInpt = FindObjectOfType<PlayerInput>();
            Player player = FindObjectOfType<Player>();

            audioManager.OnPlayDeathSFX();
            particlesVFX.OnPlayerDeathVFX(gameObject.transform);

            playerSpriteRenderer.enabled = false;
            playerBoxCollider2D.enabled = false;
            player.enabled = false;
            playerInpt.enabled = false;

            StartCoroutine(LoadGameOverScene());
            //Time.timeScale = 0;
            //Display UI
        }
    }

    private void PlayerNormalHealth()
    {
        if (health >= 90 && gameObject.tag == "Player")
        {

            heartOne1.SetActive(true);
            heartTwo2.SetActive(true);
            heartThree3.SetActive(true);
        }
        else if (health == 60 && gameObject.tag == "Player")
        {
            heartOne1.SetActive(true);
            heartTwo2.SetActive(true);
            heartThree3.SetActive(false);
        }
        else if (health == 30 && gameObject.tag == "Player")
        {
            heartOne1.SetActive(true);
            heartTwo2.SetActive(false);
            heartThree3.SetActive(false);
        }
        else if (health <= 0 && gameObject.tag == "Player")
        {
            heartOne1.SetActive(false);
            heartTwo2.SetActive(false);
            heartThree3.SetActive(false);
        }

    }

    //Upgrade
    private void PlayerHealthStatus()
    {
        if (health <= 150 && gameObject.tag == "Player")
        {
            heartOne.SetActive(true);
            heartTwo.SetActive(true);
            heartThree.SetActive(true);
            heartFour.SetActive(true);
        }
        else
        {
            heartOne.SetActive(false);
            heartTwo.SetActive(false);
            heartThree.SetActive(false);
            heartFour.SetActive(false);
        }
    }

    private IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(3);
        StopCoroutine(LoadGameOverScene());

    }

}
