using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A : AttackTypes
{
    [SerializeField] Transform target;
    [SerializeField] float enemySpeed;
    [SerializeField] Vector3 enemyOffset;

    [SerializeField] float rotationSpeed = 1.0f;
    [SerializeField] private float rotationModifier;


    [SerializeField][Range(0, 1)] float enemySpeedToThePoint;
    [SerializeField] List<GameObject> waypointsStaticLoctation;

    [SerializeField] int randompoint;

    private int firstPoint;
    private int lastPoint;

    private void Awake()
    {
        target = FindObjectOfType<Player>().gameObject.transform;
    }

    private void Start()
    {
        firstPoint = waypointsStaticLoctation.IndexOf(waypointsStaticLoctation[0], 0);
        lastPoint = waypointsStaticLoctation.Count;

        randompoint = Random.Range(firstPoint, lastPoint);

    }
    private void Update()
    {
        AttackType();
    }

    public override void AttackType()
    {
        enemyHealth = 120;
        attackName = "Moving To defend an area: in 50% height of the screen ";

        transform.position = Vector3.Lerp(transform.position, waypointsStaticLoctation[randompoint].transform.position, enemySpeedToThePoint);

        //transform.position = Vector2.MoveTowards(transform.position, target.transform.position + enemyOffset, enemySpeed * Time.deltaTime);




        //transform.LookAt(target, Vector3.forward);

        Vector3 targetDirection = target.transform.position - transform.position;

        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - rotationModifier;

        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, q, rotationSpeed);

        Debug.DrawRay(transform.position, targetDirection, Color.red);

    }
}
