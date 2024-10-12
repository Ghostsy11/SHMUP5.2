using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipProjectileUpgrade : MonoBehaviour
{
    UpgradesCaller upgradesCaller;
    private void Start()
    {
        upgradesCaller = FindObjectOfType<UpgradesCaller>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            upgradesCaller.UpgradeProjectileRightSide();
            Destroy(gameObject, 0.1f);
        }
    }

}
