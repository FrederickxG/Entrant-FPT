using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractTest : MonoBehaviour, IInteractable
{
   public GameObject collect;
   public GameObject Boss;
   public GameObject Clipboard;
   public int interactionType;
   public AudioSource bossAudioSource;

   
   public void Interact() 
   {

    switch (interactionType)
    {

    case 0:
   if (gameObject == collect)
   {
   collect.SetActive(false);
   Boss.SetActive(true);
   bossAudioSource.Play();
   }
   break;
   case 1:
   if (gameObject == Clipboard)
   {
    Clipboard.SetActive(false);
    SceneManager.LoadScene("Clipboard");
   }

   break;
   default:
   break;
    }
   }

   public void StopBossMusic()
{
    bossAudioSource.Stop();
}
}