using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMUpgrades : MonoBehaviour
{
    ScoreManager scoreManager;
    AudioManager audioManager;
    [Header("X,Y Free Moving Upgrade")]
    [SerializeField] Player playerScript;
    [SerializeField] int freeMoveOnXYCost;
    [SerializeField] Button moveFreelyBottonUpgrade;

    [Header("Additional Gold Upgrade")]
    [SerializeField] float timeToEarnGold;
    [SerializeField] float timeHasCollapsed;
    [SerializeField] int currentGoldEarning;
    [SerializeField] int goldUpgradeCost;
    [SerializeField] GameObject goldIcon;

    [Header("Healh Upgrade")]
    [SerializeField] Button healthStackUpButton;
    public bool healthUpgradeIsBought;
    [SerializeField] int healthStackUpUpgradeCost;
    [SerializeField] GameObject healthIcon;
    [SerializeField] GameObject heartIcon;


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
    [SerializeField] Button bulletUpgradeButton;

    [Header("Player Speed Upgreade")]
    [SerializeField] int playerSpeedUpgredeCost;
    [SerializeField] int fireRateUpgradeCost;

    [Header("Sheild Up Upgrade")]
    ShieldUp shieldUp;
    [SerializeField] int ShiedUpCost;


    [Header("Kill All Enemies Strike")]
    [SerializeField] int KillAllEnemiesSkillCost;
    [SerializeField] GameObject KillAll;
    [SerializeField] GameObject killAllIcon;

    [Header("Bullet Destroier Updgrade")]
    [SerializeField] Bullet[] bullets;
    [SerializeField] int bulletDestorierCost;
    [SerializeField] Button bulletDestroierButton;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        playerScript = FindObjectOfType<Player>();
        playerUpgrades = FindObjectOfType<PlayerUpgrades>();
        shieldUp = FindObjectOfType<ShieldUp>();
    }

    private void Update()
    {
        TimeForEarningGold();
    }

    public void MoveFreelyUpgrade()
    {
        if (scoreManager.GetGold() > freeMoveOnXYCost)
        {

            scoreManager.RemoveGold(freeMoveOnXYCost);
            playerScript.paddingTop = 0;
            playerScript.paddingBottom = 0;
            moveFreelyBottonUpgrade.interactable = false;
        }
    }

    public void PlayerMoveFaster()
    {
        if (scoreManager.GetGold() > playerSpeedUpgredeCost)
        {

            scoreManager.RemoveGold(playerSpeedUpgredeCost);
            playerScript.playerSpeed += 1f;
        }
        else
        {
            audioManager.ErrorSFX();
        }
    }
    public void EarnAdditionalGold()
    {
        goldIcon.SetActive(true);
        if (currentGoldEarning != 11 && scoreManager.GetGold() >= goldUpgradeCost)
        {
            scoreManager.RemoveGold(goldUpgradeCost);
            currentGoldEarning += 1;
        }
        else { audioManager.ErrorSFX(); return; }
    }

    public void StackHealthUpgrade()
    {
        if (scoreManager.GetGold() >= healthStackUpUpgradeCost)
        {
            healthUpgradeIsBought = true;
            healthIcon.SetActive(true);
            heartIcon.SetActive(true);
            healthStackUpButton.interactable = false;
        }
        else
        {
            audioManager.ErrorSFX(); return;
        }


    }

    public void UpgradeProjectileFireRate()
    {
        if (scoreManager.GetGold() >= fireRateUpgradeCost)
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
        else
        {
            audioManager.ErrorSFX();
        }
    }

    public void ProjectileUpgrade()
    {
        if (scoreManager.GetGold() >= bulletUpgradeCost || scoreManager.GetGold() >= bulletUpgradeCost1 || scoreManager.GetGold() >= bulletUpgradeCost2 || scoreManager.GetGold() >= bulletUpgradeCost3 || scoreManager.GetGold() >= bulletUpgradeCost5_4)
        {


            if (playerUpgrades.upgrade1IsBought != true)
            {
                scoreManager.RemoveGold(bulletUpgradeCost);
                playerUpgrades.upgrade1IsBought = true;
                audioManager.OnUpgradeUp();
            }
            else if (playerUpgrades.upgrade1IsBought == true && playerUpgrades.upgrade2IsBought != true)
            {
                scoreManager.RemoveGold(bulletUpgradeCost1);
                playerUpgrades.upgrade2IsBought = true;
                audioManager.OnUpgradeUp();
            }
            else if (playerUpgrades.upgrade1IsBought == true && playerUpgrades.upgrade2IsBought == true && playerUpgrades.upgrade3IsBought != true)
            {
                scoreManager.RemoveGold(bulletUpgradeCost2);
                playerUpgrades.upgrade3IsBought = true;
                audioManager.OnUpgradeUp();
            }
            else if (playerUpgrades.upgrade1IsBought == true && playerUpgrades.upgrade2IsBought == true && playerUpgrades.upgrade3IsBought == true && playerUpgrades.upgrade4IsBought != true)
            {
                scoreManager.RemoveGold(bulletUpgradeCost3);
                playerUpgrades.upgrade4IsBought = true;
                audioManager.OnUpgradeUp();
            }
            else if (playerUpgrades.upgrade1IsBought == true && playerUpgrades.upgrade2IsBought == true && playerUpgrades.upgrade3IsBought == true && playerUpgrades.upgrade4IsBought == true &&
                      playerUpgrades.upgrade5IsBought != true &&
                      playerUpgrades.upgrade6IsBought != true)
            {
                scoreManager.RemoveGold(bulletUpgradeCost5_4);
                playerUpgrades.upgrade5IsBought = true;
                playerUpgrades.upgrade6IsBought = true;
                audioManager.OnUpgradeUp();
                bulletUpgradeButton.interactable = false;
            }
        }
        else
        {
            audioManager.ErrorSFX();
        }
    }

    //Finished
    public void ShieldUpUpgrade()
    {
        if (scoreManager.GetGold() > ShiedUpCost)
        {
            audioManager.SuccesAudioSort1SFX();
            scoreManager.RemoveGold(ShiedUpCost);
            if (shieldUp.enabled == true)
            {
                shieldUp.shieldUpTimer += 1f;
            }
            else
            {
                shieldUp.enabled = true;
            }
        }
        else
        {
            audioManager.ErrorSFX();
        }

    }

    public void KillAllSkillUpgrede()
    {
        scoreManager.RemoveGold(KillAllEnemiesSkillCost);
        killAllIcon.SetActive(true);
        KillAll.SetActive(true);
    }


    public void BulletDestroies()
    {
        if (scoreManager.GetGold() >= bulletDestorierCost)
        {

            bullets[0].activitied = true;
            bullets[1].activitied = true;
            bullets[2].activitied = true;
            bullets[3].activitied = true;
            bullets[4].activitied = true;
            bullets[5].activitied = true;
            bulletDestroierButton.interactable = false;

        }
        else
        {
            audioManager.ErrorSFX();
        }
    }

    //
    private void TimeForEarningGold()
    {
        timeHasCollapsed += Time.deltaTime;
        if (timeHasCollapsed > timeToEarnGold)
        {
            scoreManager.AddGold(currentGoldEarning);
            timeHasCollapsed = 0;
        }
        else
        {
            return;
        }
    }

}
