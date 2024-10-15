using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFreelyXY : MonoBehaviour
{
    ScoreManager scoreManager;

    [Header("X,Y Free Moving Upgrade")]
    [SerializeField] Player playerScript;
    [SerializeField] int freeMoveOnXYCost;

    [Header("Additional Gold Upgrade")]
    [SerializeField] float timeToEarnGold;
    [SerializeField] float timeHasCollapsed;
    [SerializeField] int currentGoldEarning;
    [SerializeField] int goldUpgradeCost;
    [SerializeField] GameObject goldIcon;

    [Header("Healh Upgrade")]
    public bool healthUpgradeIsBought;
    [SerializeField] GameObject healthIcon;

    [Header("Projectile - Speed - Upgrades")]
    [SerializeField] PlayerUpgrades playerUpgrades;

    [Header("Projectile Upgrade The Star Icon")]
    [SerializeField] GameObject bulletUpgradeIcon;
    [SerializeField] GameObject bulletUpgradeIcon1;
    [SerializeField] GameObject bulletUpgradeIcon2;
    [SerializeField] GameObject bulletUpgradeIcon3;

    [Header("Projectile Upgrades Costs")]
    [SerializeField] int bulletUpgradeCost;
    [SerializeField] int bulletUpgradeCost1;
    [SerializeField] int bulletUpgradeCost2;
    [SerializeField] int bulletUpgradeCost3;
    [SerializeField] int bulletUpgradeCost5_4;

    [Header("Player Speed Upgreade")]
    [SerializeField] int playerSpeedUpgredeCost;

    [Header("Sheild Up Upgrade")]
    ShieldUp shieldUp;
    [SerializeField] int ShiedUpCost;


    [Header("Kill All Enemies Strike")]
    [SerializeField] int KillAllEnemiesSkillCost;
    [SerializeField] GameObject KillAll;
    [SerializeField] GameObject killAllIcon;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        playerUpgrades = FindObjectOfType<PlayerUpgrades>();
        shieldUp = FindObjectOfType<ShieldUp>();
    }

    private void Update()
    {
        TimeForEarningGold();
    }

    public void MoveFreelyUpgrade()
    {
        scoreManager.RemoveGold(freeMoveOnXYCost);
        playerScript.paddingTop = 0;
        playerScript.paddingBottom = 0;
    }

    public void PlayerMoveFaster()
    {
        scoreManager.RemoveGold(playerSpeedUpgredeCost);
        playerScript.playerSpeed += 1f;
    }
    public void EarnAdditionalGold()
    {
        goldIcon.SetActive(true);
        if (currentGoldEarning != 11)
        {
            scoreManager.RemoveGold(goldUpgradeCost);
            currentGoldEarning += 1;
        }
        else { return; }
    }

    public void StackHealthUpgrade()
    {
        healthUpgradeIsBought = true;
        healthIcon.SetActive(true);
    }

    public void UpgradeProjectileFireRate()
    {
        if (playerUpgrades.miniumFiringRate != 0.01f && playerUpgrades.baseFiringRate != 0.01f)
        {
            if (playerUpgrades.miniumFiringRate != 0.01)
            {
                playerUpgrades.miniumFiringRate -= 0.01f;
            }

            if (playerUpgrades.baseFiringRate != 0.01f)
            {
                playerUpgrades.baseFiringRate -= 0.01f;
            }
        }
    }

    public void ProjectileUpgrade()
    {
        if (playerUpgrades.upgrade1IsBought != true)
        {
            scoreManager.RemoveGold(bulletUpgradeCost);
            playerUpgrades.upgrade1IsBought = true;
        }
        else if (playerUpgrades.upgrade1IsBought == true && playerUpgrades.upgrade2IsBought != true)
        {
            scoreManager.RemoveGold(bulletUpgradeCost1);
            playerUpgrades.upgrade2IsBought = true;
        }
        else if (playerUpgrades.upgrade1IsBought == true && playerUpgrades.upgrade2IsBought == true && playerUpgrades.upgrade3IsBought != true)
        {
            scoreManager.RemoveGold(bulletUpgradeCost2);
            playerUpgrades.upgrade3IsBought = true;
        }
        else if (playerUpgrades.upgrade1IsBought == true && playerUpgrades.upgrade2IsBought == true && playerUpgrades.upgrade3IsBought == true && playerUpgrades.upgrade4IsBought != true)
        {
            scoreManager.RemoveGold(bulletUpgradeCost3);
            playerUpgrades.upgrade4IsBought = true;
        }
        else if (playerUpgrades.upgrade1IsBought == true && playerUpgrades.upgrade2IsBought == true && playerUpgrades.upgrade3IsBought == true && playerUpgrades.upgrade4IsBought == true &&
                  playerUpgrades.upgrade5IsBought != true &&
                  playerUpgrades.upgrade6IsBought != true)
        {
            scoreManager.RemoveGold(bulletUpgradeCost5_4);
            playerUpgrades.upgrade5IsBought = true;
            playerUpgrades.upgrade6IsBought = true;
        }
    }

    public void ShieldUpUpgrade()
    {
        scoreManager.RemoveGold(ShiedUpCost);
        shieldUp.enabled = true;
    }

    public void KillAllSkillUpgrede()
    {
        scoreManager.RemoveGold(KillAllEnemiesSkillCost);
        killAllIcon.SetActive(true);
        KillAll.SetActive(true);
    }


    //
    private void TimeForEarningGold()
    {
        timeToEarnGold += Time.deltaTime;
        if (timeToEarnGold >= timeHasCollapsed)
        {
            scoreManager.AddGold(currentGoldEarning);
            timeToEarnGold = 0;
        }
    }

}
