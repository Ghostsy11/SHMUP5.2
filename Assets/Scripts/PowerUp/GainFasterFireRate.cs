using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainFasterFireRate : MonoBehaviour
{
    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var c = collision.gameObject.GetComponent<PlayerUpgrades>();
            FindObjectOfType<AudioManager>().OnProjectileUpgradeUp();
            if (c.miniumFiringRate != 0.2f)
            {
                c.miniumFiringRate -= 0.05f;
            }

            if (c.baseFiringRate != 0.4f)

            {
                c.baseFiringRate -= 0.1f;
            }

            Destroy(gameObject);
        }
    }

}
