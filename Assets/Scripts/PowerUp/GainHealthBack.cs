using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainHealthBack : MonoBehaviour
{
    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        Destroy(gameObject, 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var c = collision.gameObject.GetComponent<ShipHealth>();

            if (c.health != 90)
            {
                audioManager.OnHealUpH();
                c.health += 30;
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);

            }

            Debug.Log("Health Regained");


        }
    }
}
