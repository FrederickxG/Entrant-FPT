using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour
{
    public Transform player;
    public float speed = 2.0f;
    public float attackRange = 1.0f;
    public float attackDamage = 10.0f;
    public bool isAttacking = false;

    void Update()
    {
        //Find the distance between the enemy and the player
        float distance = Vector3.Distance(transform.position, player.position);

       // If the player is within range, attack the player
        if (distance <= attackRange && !isAttacking)
        {
            StartCoroutine(Attack());
        }
        // Otherwise, move towards the player
        else
        {
            transform.LookAt(player);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

     IEnumerator Attack()
    {
        isAttacking = true;

        // Deal damage to the player
        player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);

        // Wait for a few seconds before attacking again
        yield return new WaitForSeconds(2.0f);

        isAttacking = false;
    }
}
