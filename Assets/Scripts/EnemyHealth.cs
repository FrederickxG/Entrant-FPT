using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IDamageable
{
    void TakeDamage(float damage);
}

public class EnemyHealth : MonoBehaviour, IDamageable
{
   public float health = 35f; 
    
   public void TakeDamage(float damage)
   {
    health -= damage;
    if (health <= 0)
       Destroy(gameObject);
    }
}