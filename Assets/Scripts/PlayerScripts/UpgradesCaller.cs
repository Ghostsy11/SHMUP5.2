using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesCaller : MonoBehaviour
{
    [Header("Scripts Refrances managed via code")]
    [SerializeField] PlayerUpgrades playerUpgrades;
    [SerializeField] AudioManager audioManager;

    [Header("Visual Updates along with Updates")]
    [SerializeField] GameObject shipLevel1;
    [SerializeField] GameObject shipLevel2;
    [SerializeField] GameObject shipLevel3;
    [SerializeField] GameObject shipLevel4;

    [SerializeField] GameObject iconshipLevel1;
    [SerializeField] GameObject iconshipLevel2;
    [SerializeField] GameObject iconshipLevel3;
    [SerializeField] GameObject iconshipLevel4;

    private void Awake()
    {
        playerUpgrades = FindObjectOfType<PlayerUpgrades>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void UpgradeProjectileRightSide()
    {
        audioManager.OnUpgradeUp();

        playerUpgrades.upgrade1IsBought = true;
        iconshipLevel2.SetActive(true);
        iconshipLevel1.SetActive(false);
        shipLevel1.SetActive(false);
        shipLevel2.SetActive(true);

    }


    public void UpgradeProjectileLeftSide()
    {
        audioManager.OnUpgradeUp();

        playerUpgrades.upgrade2IsBought = true;

        iconshipLevel3.SetActive(true);
        iconshipLevel2.SetActive(false);
        shipLevel2.SetActive(false);
        shipLevel3.SetActive(true);
    }

    public void UpgradeProjectileLeftSideSecondPro()
    {
        audioManager.OnUpgradeUp();

        playerUpgrades.upgrade3IsBought = true;

        iconshipLevel3.SetActive(true);
        iconshipLevel2.SetActive(false);
        shipLevel2.SetActive(false);
        shipLevel3.SetActive(true);
    }

    public void UpgradeProjectileRightSideSecondPro()
    {
        audioManager.OnUpgradeUp();

        playerUpgrades.upgrade4IsBought = true;

        iconshipLevel4.SetActive(true);
        iconshipLevel3.SetActive(false);
        shipLevel3.SetActive(false);
        shipLevel4.SetActive(true);
    }
}
