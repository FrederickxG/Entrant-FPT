using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
 [Header("Sway Settings")]
    [SerializeField] private float smooth;
    [SerializeField] private float swayMultiplier;

    // Update is called once per frame
    void Update()
    {
        // takes axis and allows sway mutipler to be added
        float mouseX = Input.GetAxisRaw("Mouse X") * swayMultiplier; 
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayMultiplier;

        //makes gun sway
        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion targetRotation = rotationX * rotationY; 

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
    }
}
