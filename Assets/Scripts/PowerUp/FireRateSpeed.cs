using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class FireRateSpeed : MonoBehaviour
{

    private PlayerUpgrades c;
    [SerializeField] Renderer sprite;

    private void Start()
    {
        Destroy(gameObject, 12f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            c = collision.gameObject.GetComponent<PlayerUpgrades>();
            sprite.enabled = false;
            StartCoroutine(c.TimeBuffManager());
            Destroy(gameObject);

        }
    }



}
