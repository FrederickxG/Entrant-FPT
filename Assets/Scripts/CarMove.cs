using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarMove : MonoBehaviour
{
     public float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

 void OnCollisionEnter(Collision collision)
{
    // Get the colliding object
    GameObject collidingObject = collision.gameObject;

    // Check if the colliding object has a specific tag
    if (collidingObject.CompareTag("VillageEntrance"))
    {
        // Teleport the car to the "Village" scene
        SceneManager.LoadScene("Village");
    }
}
}