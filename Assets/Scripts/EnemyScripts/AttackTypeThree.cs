using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AttackTypeThree : AttackTypes
{

    [SerializeField] GameObject targetPlayer;
    [SerializeField][Range(0, 1)] float enemySpeedToThePoint;
    [SerializeField] List<GameObject> waypointsStaticLoctation;


    [SerializeField] float rotationModifier;
    [SerializeField] float rotationSpeed;
    [SerializeField] int randompoint;

    private int firstPoint;
    private int lastPoint;

    private void Start()
    {
        firstPoint = waypointsStaticLoctation.IndexOf(waypointsStaticLoctation[0], 0);
        lastPoint = waypointsStaticLoctation.Count;

        randompoint = Random.Range(firstPoint, lastPoint);

    }
    private void Update()
    {


        AttackType();
        if (Input.GetKeyDown(KeyCode.T))
        {

            Debug.Log(randompoint);
        }
        //Debug.Log("Screen height: " + Screen.height);
    }

    public override void AttackType()
    {
        enemyHealth = 120;
        attackName = "Moving To defend an area: in 50% height of the screen ";

        transform.position = Vector3.Lerp(transform.position, waypointsStaticLoctation[randompoint].transform.position, enemySpeedToThePoint);



        Vector3 targetDirection = targetPlayer.transform.position - transform.position;

        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - rotationModifier;

        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Lerp(transform.rotation, q, rotationSpeed);

        Debug.DrawRay(transform.position, targetDirection, Color.red);
    }

}