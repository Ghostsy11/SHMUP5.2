using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounders : MonoBehaviour
{
    [SerializeField] BoxCollider2D playerBoxColider;

    [Header("Ship limtation")]
    [SerializeField] float minXaxis = -3.9f;
    [SerializeField] float maxXaxis = 3.9f;
    [SerializeField] float minYaxis = -3.5f;
    [SerializeField] float maxYaxis = 4.35f;

    [Header("Locations out come")]
    [SerializeField] float minXShipLocation = -3.8f;
    [SerializeField] float maxXShipLocation = 3.8f;
    [SerializeField] float minYShipLocation = -3f;
    [SerializeField] float maxYShipLocation = 4f;


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
        if (transform.position.x >= maxXShipLocation)
        {
            playerBoxColider.enabled = false;
            transform.position = new Vector3(minXaxis, transform.position.y, 0);
            playerBoxColider.enabled = true;

        }

        if (transform.position.x <= minXShipLocation)
        {
            playerBoxColider.enabled = false;
            transform.position = new Vector3(maxXaxis, transform.position.y, 0);
            playerBoxColider.enabled = true;

        }

        if (transform.position.y >= maxYShipLocation)
        {
            playerBoxColider.enabled = false;
            transform.position = new Vector3(transform.position.x, minYaxis, 0);
            playerBoxColider.enabled = true;

        }

        if (transform.position.y <= minYShipLocation)
        {
            playerBoxColider.enabled = false;
            transform.position = new Vector3(transform.position.x, maxYaxis, 0);
            playerBoxColider.enabled = true;

        }

    }
}
