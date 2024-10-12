using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTypeTwo : AttackTypes
{
    [SerializeField] private float enemySpeed;
    [SerializeField] private float XaxisReset = -15;
    [SerializeField] private float YaxisReseZ;

    private void Update()
    {
        AttackType();
    }

    private void Start()
    {
        transform.position = new Vector3(0f, 4.5f, 0f);

    }
    public override void AttackType()
    {
        enemyHealth = 120;
        attackName = "Attack Type two static x axis ";

        transform.position += Vector3.right * enemySpeed * Time.deltaTime;

        if (transform.position.x >= 9)
        {
            //Debug.Log("It passed 9");
            transform.position = new Vector3(XaxisReset, transform.position.y, transform.position.z);

        }

    }

}
