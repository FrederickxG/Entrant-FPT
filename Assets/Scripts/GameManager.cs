using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject freya;
    public AudioSource freyaAudioSource;
    public GameObject freyaV;
    public AudioSource freyaVAudioSource;
    public GameObject freyaA;
    public AudioSource freyaAAudioSource;
    public ObjectiveManager objectiveManager;

    private bool freyaObjectiveSet = false;
    private bool freyaVObjectiveSet = false;
    private bool freyaaObjectiveSet = false; // Ensure this is the correct variable name

    // Start is called before the first frame update
    void Start()
    {
        if (freya != null && freyaAudioSource != null)
        {
            freya.SetActive(true);
            freyaAudioSource.Play();
        }
        else if (freyaV != null && freyaVAudioSource != null)
        {
            freyaV.SetActive(true);
            freyaVAudioSource.Play();
        }
        else if (freyaA != null && freyaAAudioSource != null)
        {
            freyaA.SetActive(true);
            freyaAAudioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (freya != null && !freyaObjectiveSet)
        {
            // Check if freya's audio has finished and set the objective if not already set
            if (!freyaAudioSource.isPlaying)
            {
                freya.SetActive(false);
                objectiveManager.SetObjective("Find the clipboard");
                freyaObjectiveSet = true; // Mark the objective as set
                // Check if freyaV is set, then start its sequence
                if (freyaV != null && freyaVAudioSource != null)
                {
                    freyaV.SetActive(true);
                    freyaVAudioSource.Play();
                }
            }
        }

        if (freyaV != null && !freyaVObjectiveSet)
        {
            // Check if freyaV's audio has finished and set the objective if not already set
            if (!freyaVAudioSource.isPlaying)
            {
                freyaV.SetActive(false);
                objectiveManager.SetObjective("Find adriks shack");
                freyaVObjectiveSet = true; // Mark the objective as set
                // Check if freyaA is set, then start its sequence
                if (freyaA != null && freyaAAudioSource != null)
                {
                    freyaA.SetActive(true);
                    freyaAAudioSource.Play();
                }
            }
        }

        if (freyaA != null && !freyaaObjectiveSet)
        {
            // Check if freyaA's audio has finished and set the objective if not already set
            if (!freyaAAudioSource.isPlaying)
            {
                freyaA.SetActive(false);
                objectiveManager.SetObjective("Find the security card");
                freyaaObjectiveSet = true; // Mark the objective as set
            }
        }
    }
}
