using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RotateProjectileToPlayer : MonoBehaviour
{
    private Player target;
    [SerializeField] private float rotationModifier;
    [SerializeField] private float rotationSpeed;


    private void Start()
    {
        target = FindObjectOfType<Player>();
        RotateToPlayer();
    }


    private void RotateToPlayer()
    {
        Vector3 targetDirection = target.transform.position - transform.position;

        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - rotationModifier;

        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, q, rotationSpeed);
    }

}
