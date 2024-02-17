using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCar : MonoBehaviour
{
    public GameObject car;
    public Vector3 offset = new Vector3(0, 0, -5);
    
    void LateUpdate()
    {
        transform.position = car.transform.position + offset;
    }
}