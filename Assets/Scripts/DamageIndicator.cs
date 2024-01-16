using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIndicator : MonoBehaviour
{
    public float duration = 2f; // Time for the damage indicator to stay visible
    public GameObject damageScreenEdge; 
    public Health health;

    private void Start()
    {
        damageScreenEdge.SetActive(false); // Hide the damage screen edge at the start
    }

    public void ShowDamageIndicator()
    {
        damageScreenEdge.SetActive(true); // Show the damage screen edge
        Invoke("HideDamageIndicator", duration); // Hide the damage screen edge after a certain amount of time
    }

    private void HideDamageIndicator()
    {
        damageScreenEdge.SetActive(false); // Hide the damage screen edge
    }
}