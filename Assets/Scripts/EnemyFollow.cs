using System.Collections;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform component
    public float moveSpeed = 5f; // Speed at which the enemy moves towards the player
    public float detectionRange = 10f; // Range at which the enemy detects the player
    public float attackInterval = 2f;
    public float attackDistance = 2f;
    public int attackDamage = 10;

    private float timer;
    private bool canAttack;
    private Health health;
    private Vector3 groundNormal; // Stores the normal of the ground surface

    private void Start()
    {
        health = FindObjectOfType<Health>();
        timer = 0f; // Initialize the timer
        canAttack = true;
    }

    private void Update()
    {
        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the detection range
        if (distanceToPlayer <= detectionRange)
        {
            // Move the enemy towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            // Rotate the enemy to face the player (optional)
            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);

            // Handle attacking behavior
            timer += Time.deltaTime;
            if (timer >= attackInterval && canAttack)
            {
                canAttack = false;
                timer = 0f; // Reset the timer

                // Perform attack animation and damage
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

        yield return new WaitForSeconds(attackInterval); // Wait for the attack interval
        canAttack = true; // Allow attacking again
    }
}