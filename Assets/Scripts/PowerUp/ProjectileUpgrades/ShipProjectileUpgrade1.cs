using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipProjectileUpgrade1 : MonoBehaviour
{
    UpgradesCaller upgradesCaller;
    private void Start()
    {
        upgradesCaller = FindObjectOfType<UpgradesCaller>();
        Destroy(gameObject, 5);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            upgradesCaller.UpgradeProjectileLeftSide();
            Destroy(gameObject, 0.1f);
        }
    }

}
