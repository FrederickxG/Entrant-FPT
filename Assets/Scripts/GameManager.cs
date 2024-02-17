using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

     public GameObject freya; 
     public AudioSource audioSource;   


    // Start is called before the first frame update
 void Start()
{
    freya.SetActive(true);
    audioSource.Play();
}

// Update is called once per frame
void Update()
{
    if (!audioSource.isPlaying)
    {
        freya.SetActive(false);
    }
}

}