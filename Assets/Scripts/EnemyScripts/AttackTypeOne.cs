using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTypeOne : AttackTypes
{
    [SerializeField] Player target;
    [SerializeField] float enemySpeed;
    [SerializeField] Vector3 enemyOffset;

    [SerializeField] float rotationSpeed = 1.0f;
    [SerializeField] private float rotationModifier;

    private void Start()
    {
        target = FindObjectOfType<Player>();
        //Debug.Log(attackName);
    }
    private void Update()
    {
        AttackType();
    }

    public override void AttackType()
    {
        enemyHealth = 100;

        attackName = "Go Torwards Player";

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position + enemyOffset, enemySpeed * Time.deltaTime);

        Vector3 targetDirection = target.transform.position - transform.position;

        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - rotationModifier;

        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, q, rotationSpeed);

        Debug.DrawRay(transform.position, targetDirection, Color.red);

    }
}
