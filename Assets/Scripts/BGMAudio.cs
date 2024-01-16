using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMAudio : MonoBehaviour
{
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
    }
}

