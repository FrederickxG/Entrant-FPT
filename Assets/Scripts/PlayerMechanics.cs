using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMechanics : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth = 100;

    PlayerHealth playerHealthScript;

    void Awake()
    {
        playerHealthScript = GetComponent<PlayerHealth>();
        }
}