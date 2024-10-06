using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            Debug.Log("Destroy: " + other.gameObject.name);
        }
    }
}
