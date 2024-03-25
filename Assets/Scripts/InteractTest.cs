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
    public AudioClip adrikHos; 
    public Camera mainCamera;
    public CameraShaker cameraShaker;
    public GameObject[] enemies; // Array to store references to all the enemies
    public GameObject card;

    private int currentEnemyIndex = 0; // Index to track the current enemy

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
            case 3: 
                if (gameObject == card)
                {
                    StartCoroutine(InteractWithEnemy());
                }
                break;
            case 4: // New case for interacting with the door
                if (gameObject == Door)
                {
                    StartCoroutine(ActivateCommsDeviceAndSwitchScene());
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

 IEnumerator InteractWithEnemy()
{
    while (currentEnemyIndex < enemies.Length)
    {
        // Activate the current enemy
        enemies[currentEnemyIndex].SetActive(true);

        // Rotate towards the current enemy
        Vector3 direction = (enemies[currentEnemyIndex].transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);

        // Wait for the current enemy to be destroyed or become null
        while (enemies[currentEnemyIndex] != null && enemies[currentEnemyIndex].activeSelf)
        {
            yield return null;
        }

        // Move to the next enemy
        currentEnemyIndex++;
    }
}


    IEnumerator ActivateCommsDeviceAndSwitchScene()
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

        // Load the desired scene
        SceneManager.LoadScene("Decable");
    }

    public void StopBossMusic()
    {
        bossAudioSource.Stop();
    }
}
