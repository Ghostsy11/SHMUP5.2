using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackHealthUp : MonoBehaviour
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

            audioManager.OnHealUpH();
            c.health += 30;
            Destroy(gameObject);

        }
    }
}
