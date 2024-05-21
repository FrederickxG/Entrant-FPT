using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

interface IInteractable
{
    public void Interact();
}

public class Interaction : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;
    public TMP_Text interactionText; // Reference to the TMP Text element

    private void Start()
    {
        interactionText.gameObject.SetActive(false); // Initially deactivate the interaction text
    }

    private void Update()
    {
        // Cast a ray from the InteractorSource forward to detect interactable objects
        Ray ray = new Ray(InteractorSource.position, InteractorSource.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractRange))
        {
            // Check if the hit object has the IInteractable interface
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                // Display interaction prompt text
                interactionText.text = "Press E to interact with " + hitInfo.collider.gameObject.name;

                // Enable the interaction text
                interactionText.gameObject.SetActive(true);

                // Check for player input to interact with the object
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactObj.Interact(); // Call the Interact method of the interactable object
                }
            }
            else
            {
                // No interactable object detected, deactivate the interaction text
                interactionText.gameObject.SetActive(false);
            }
        }
        else
        {
            // No interactable object detected, deactivate the interaction text
            interactionText.gameObject.SetActive(false);
        }
    }
}
