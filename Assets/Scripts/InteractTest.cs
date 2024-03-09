using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractTest : MonoBehaviour, IInteractable
{
    public GameObject collect;
    public GameObject Boss;
    public GameObject Clipboard;
    public int interactionType;
    public AudioSource bossAudioSource;
    public GameObject commsDevice;
    public AudioClip commsAudioClip;
    public GameObject Door;
    public AudioClip adrikVL;
    public Camera mainCamera;
    public CameraShaker cameraShaker;

   public void Interact() 
   {
       switch (interactionType)
       {
           case 0:
               if (gameObject == collect)
               {
                   StartCoroutine(ActivateCommsDeviceAndSpawnBoss());
               }
               break;
           case 1:
               if (gameObject == Clipboard)
               {
                   Clipboard.SetActive(false);
                   SceneManager.LoadScene("Clipboard");
               }
               break;
           case 2:
               if (gameObject == Door)
               {
                   StartCoroutine(PlayAdrikVLAudioAndSwitchScene());
               }
               break;
           default:
               break;
       }
   }
   
  
    IEnumerator PlayAdrikVLAudioAndSwitchScene()
    {
        // Play the AdrikVL audio clip
        AudioSource.PlayClipAtPoint(adrikVL, transform.position);

        // Wait for the audio clip to finish playing
        yield return new WaitForSeconds(adrikVL.length);

        // Shake the camera
        cameraShaker.Shake();

        // Load the desired scene
        SceneManager.LoadScene("Knocked");
    }

   IEnumerator ActivateCommsDeviceAndSpawnBoss()
   {
       // Activate comms device and play audio clip
       commsDevice.SetActive(true);
       AudioSource commsAudioSource = commsDevice.GetComponent<AudioSource>();
       commsAudioSource.clip = commsAudioClip;
       commsAudioSource.Play();

       // Wait for audio clip to finish playing
       yield return new WaitForSeconds(commsAudioClip.length);

       // Deactivate comms device
       commsDevice.SetActive(false);

       // Spawn boss and play boss music
       collect.SetActive(false);
       Boss.SetActive(true);
       bossAudioSource.Play();
   }

   public void StopBossMusic()
   {
       bossAudioSource.Stop();
   }
}
