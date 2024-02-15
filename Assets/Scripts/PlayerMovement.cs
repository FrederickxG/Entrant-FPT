using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
private bool isCrouching = false;
private float crouchHeight = 0.5f;
private float standHeight = 1.0f;
private Rigidbody rb;
public float dashForce;


void Start()
{
rb = GetComponent<Rigidbody>();
dashForce = 1000;
}

void Update()
{
if (Input.GetKeyDown(KeyCode.C))
{
isCrouching = !isCrouching;
}

if (isCrouching)
{
transform.localScale = new Vector3(1, crouchHeight, 1);
}

else
{
transform.localScale = new Vector3(1, standHeight, 1);
} 

if (Input.GetKeyDown(KeyCode.Z))
{
rb.AddForce(transform.forward * dashForce);
}

}
}

