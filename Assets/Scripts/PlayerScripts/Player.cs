using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Tooltip("When Player Press a button it returns and store the vaule in playerinput vector")]
    [SerializeField] Vector2 playerInput;

    [Tooltip("Player Movement Speed")]
    public float playerSpeed = 5f;

    [Header("Player Screen and player Bounders")]
    [Tooltip("PlayerBounders")]
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;

    [Tooltip("Screen Bounders")]
    Vector2 minimalBounds;
    Vector2 maximalBounds;

    [Tooltip("Player Bounders")]
    [SerializeField] private float XaxisReset;
    [SerializeField] private float YaxisReseZ;

    PlayerUpgrades playerUpgrade;
    Shooter shooter;
    KillAllEnemies killAllEnemiesSkillScript;
    ShieldUp shieldUpSkillScript;

    [SerializeField] GameObject init;



    private void Awake()
    {
        shooter = GetComponent<Shooter>();
        playerUpgrade = GetComponent<PlayerUpgrades>();
        killAllEnemiesSkillScript = FindObjectOfType<KillAllEnemies>();
        shieldUpSkillScript = GetComponent<ShieldUp>();
    }
    private void Start()
    {
        InitBounds();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Instantiate(init, new Vector3(0, 0, 0), Quaternion.identity);
        }
        OnMoveHandler();


    }


    // Player Input Function
    private void OnMove(InputValue value)
    {
        playerInput = value.Get<Vector2>();
        //For more explanation
        //Debug.Log(playerInput);
    }

    // To calcalate the player movement
    private void OnMoveHandler()
    {
        Vector2 movemeant = playerInput * playerSpeed * Time.deltaTime;

        Vector2 newPosition = new Vector2();
        newPosition.x = Mathf.Clamp(transform.position.x + movemeant.x, minimalBounds.x + paddingLeft, maximalBounds.x - paddingRight);
        newPosition.y = Mathf.Clamp(transform.position.y + movemeant.y, minimalBounds.y + paddingBottom, maximalBounds.y - paddingTop);

        transform.position = newPosition;

    }
    //  To Initalize the screen Bounders
    private void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minimalBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maximalBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    // To Initalize player Bounders

    public void PlayerBounders()
    {

    }

    // Inputs
    private void OnFire(InputValue value)
    {
        if (shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }


    }

    private void OnPlayerFire(InputValue value)
    {
        Debug.Log("Space Bot working");
        if (playerUpgrade != null)
        {
            playerUpgrade.isFiring = value.isPressed;
        }
    }

    private void OnKillAll(InputValue value)
    {
        if (killAllEnemiesSkillScript.readyToKillAll)
        {
            StartCoroutine(killAllEnemiesSkillScript.ActivatietSkill());
            Debug.Log("Rocket to kill enemies has been Activited");
        }
        else
        {
            Debug.Log("Still loading the skill");
        }
    }

    private void OnShieldUp()
    {
        if (shieldUpSkillScript.readyToShieldUp)
        {

            StartCoroutine(shieldUpSkillScript.ActivatietShieldSkill());
            Debug.Log("Shield Up is activited");
        }
        else
        {
            Debug.Log("Shield Up is still loading");

        }

    }
}