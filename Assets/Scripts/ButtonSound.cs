using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public AudioClip clickSound; // Sound to play when clicking the button
    public AudioClip hoverSound; // Sound to play when hovering over the button

    public float hoverScaleMultiplier = 1.1f; // Scale multiplier when hovering
    private Vector3 originalScale; // Original scale of the button

    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If AudioSource component is not found, add it
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Save the original scale of the button
        originalScale = transform.localScale;
    }

    // Called when the button is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        // Play the click sound
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }

    // Called when the pointer enters the button's area
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Play the hover sound
        if (hoverSound != null)
        {
            audioSource.PlayOneShot(hoverSound);
        }

        // Scale up the button
        transform.localScale = originalScale * hoverScaleMultiplier;
    }

    // Called when the pointer exits the button's area
    public void OnPointerExit(PointerEventData eventData)
    {
        // Scale down the button to its original size
        transform.localScale = originalScale;
    }
}
