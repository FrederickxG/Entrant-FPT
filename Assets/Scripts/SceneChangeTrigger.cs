using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTrigger : MonoBehaviour
{
    // The name of the scene to load when triggered
    public string sceneToLoad;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider is the car GameObject
        if (other.CompareTag("Car"))
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
