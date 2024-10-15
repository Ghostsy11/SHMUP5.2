using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounders : MonoBehaviour
{
    [SerializeField] BoxCollider2D playerBoxColider;

    void Start()
    {
        playerBoxColider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        PlayerLimitation();
    }


    public void PlayerLimitation()
    {
        if (transform.position.x >= 3.9f)
        {
            playerBoxColider.enabled = false;
            transform.position = new Vector3(-3.8f, transform.position.y, 0);
            playerBoxColider.enabled = true;

        }

        if (transform.position.x <= -3.9f)
        {
            playerBoxColider.enabled = false;
            transform.position = new Vector3(3.8f, transform.position.y, 0);
            playerBoxColider.enabled = true;

        }

        if (transform.position.y >= 4.35f)
        {
            playerBoxColider.enabled = false;
            transform.position = new Vector3(transform.position.x, -3f, 0);
            playerBoxColider.enabled = true;

        }

        if (transform.position.y <= -3.5f)
        {
            playerBoxColider.enabled = false;
            transform.position = new Vector3(transform.position.x, 4f, 0);
            playerBoxColider.enabled = true;

        }

    }
}
