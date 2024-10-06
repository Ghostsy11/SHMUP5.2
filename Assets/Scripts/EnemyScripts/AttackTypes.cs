using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackTypes : MonoBehaviour
{
    [HideInInspector] public string attackName;
    [HideInInspector] public int enemyHealth;
    public abstract void AttackType();

}
