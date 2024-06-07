using UnityEngine;
using System.Collections;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform component
    public float moveSpeed = 5f; // Speed at which the enemy moves towards the player
    public float detectionRange = 10f; // Range at which the enemy detects the player
    public float attackInterval = 2f;
    public float attackDistance = 2f;
    public int attackDamage = 10;
    public LayerMask obstacleLayer; // Layer mask to detect obstacles (e.g., other enemies)
    public LayerMask groundLayer; // Layer mask for the ground
    public float spreadRadius = 2f; // Adjust the spread of enemies
    public float separationRadius = 1.5f; // Radius within which enemies should separate
    public float separationStrength = 5f; // Strength of the separation force
    public float groundOffset = 0.5f; // Offset to keep the zombies above the ground
    public float raycastLength = 2f; // Length of the raycast to detect the ground

    private float timer;
    private bool canAttack;
    private Health health;

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
            // Check for obstacles before moving towards the player
            if (!Physics.Raycast(transform.position, player.position - transform.position, detectionRange, obstacleLayer))
            {
                // Apply separation force to avoid stacking
                Vector3 separationForce = GetSeparationForce();

                // Calculate the target position with separation force
                Vector3 targetPosition = player.position + separationForce;

                // Move the enemy towards the target position, keeping it on the ground
                MoveTowardsTarget(targetPosition);

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
    }

    private Vector3 GetSeparationForce()
    {
        Vector3 separationForce = Vector3.zero;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, separationRadius);

        foreach (Collider collider in hitColliders)
        {
            if (collider != this.GetComponent<Collider>())
            {
                Vector3 directionToOther = transform.position - collider.transform.position;
                separationForce += directionToOther.normalized / directionToOther.magnitude;
            }
        }

        return separationForce * separationStrength;
    }

    private void MoveTowardsTarget(Vector3 targetPosition)
    {
        // Cast a ray downward to find the ground height at the target position
        RaycastHit hit;
        Vector3 targetGroundedPosition = targetPosition;

        if (Physics.Raycast(targetPosition + Vector3.up * raycastLength, Vector3.down, out hit, raycastLength * 2, groundLayer))
        {
            // Set the target position to be slightly above the ground
            targetGroundedPosition.y = hit.point.y + groundOffset;
        }
        else
        {
            // If the raycast fails, keep the target position's y-coordinate unchanged
            targetGroundedPosition.y = transform.position.y;
        }

        // Move the enemy towards the target grounded position
        transform.position = Vector3.MoveTowards(transform.position, targetGroundedPosition, moveSpeed * Time.deltaTime);

        // Ensure the enemy is always grounded
        GroundEnemy();
    }

    private void GroundEnemy()
    {
        // Cast a ray downward to adjust the enemy's position to the ground
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * raycastLength, Vector3.down, out hit, raycastLength * 2, groundLayer))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y + groundOffset, transform.position.z);
        }
    }

    public void SetSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

    public void SetDamage(int newDamage)
    {
        attackDamage = newDamage;
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
