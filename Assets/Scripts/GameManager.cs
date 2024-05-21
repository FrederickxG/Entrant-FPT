using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject freya; 
    public AudioSource audioSource;   
    public ObjectiveManager objectiveManager;
    private bool objectiveSet = false; // To ensure the objective is set only once

    // Start is called before the first frame update
    void Start()
    {
        freya.SetActive(true);
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying && !objectiveSet)
        {
            freya.SetActive(false);
            objectiveManager.SetObjective("Find the clipboard");
            objectiveSet = true; // Mark the objective as set
        }
    }
}
