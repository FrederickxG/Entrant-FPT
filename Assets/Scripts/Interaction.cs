using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class Interaction : MonoBehaviour
{
   public Transform InteractorSource;
   public float InteractRange;

   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward); // ray cast is created with the pos and dir of interaction source
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange)) 
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }
}
