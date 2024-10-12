using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrasePlayerSpeed : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var c = collision.gameObject.GetComponent<Player>();

            c.playerSpeed += 1;
            Destroy(gameObject);
            Debug.Log("Speed Buffed by one");


        }
    }
}
