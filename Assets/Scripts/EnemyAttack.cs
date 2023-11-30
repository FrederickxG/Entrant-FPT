using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float range = 10f;
    public float attackInterval = 2f;
    public float attackDistance = 2f;
    public int attackDamage = 10;
    public float moveSpeed = 3f;

    private float timer;
    private bool canAttack;
    private Health health;

    void Start()
    {
        health = FindObjectOfType<Health>();
        timer = attackInterval;
        canAttack = true;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, health.transform.position);

        if (distanceToPlayer <= range)
        {
            transform.LookAt(health.transform);
            transform.position += transform.forward * moveSpeed * Time.deltaTime; // Move towards the player

            timer -= Time.deltaTime;

            if (timer <= 0 && canAttack)
            {
                canAttack = false;
                timer = attackInterval;
                StartCoroutine(AttackPlayer());
            }
        }
    }

    IEnumerator AttackPlayer()
    {
        float distance = Vector3.Distance(transform.position, health.transform.position);

        if (distance <= attackDistance)
        {
            health.TakeDamage(attackDamage);
        }

        yield return new WaitForSeconds(0.5f);
        canAttack = true;
    }
}