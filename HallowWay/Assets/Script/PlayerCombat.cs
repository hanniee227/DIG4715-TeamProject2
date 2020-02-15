﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 1;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    private void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButton(0))
            {
                Debug.Log("attack pressed");
                Attack();
                nextAttackTime = Time.time + 1f / attackRate; //cool down time in hitting attack again
            }
        }
    }

    void Attack()
    {
        //Play Attack Animation

        //Decting Enemies in range
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        //Damage them
        foreach(Collider enemy in hitEnemies)
        {
            Debug.Log("Enemy hit");
            enemy.GetComponent<EnemyController>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
