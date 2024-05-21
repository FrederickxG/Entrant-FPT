using UnityEngine;
using TMPro;
using System.Collections;

public class ObjectiveManager : MonoBehaviour
{
    public GameObject objectivePanel; // Reference to the UI Panel acting as the backdrop
    public TextMeshProUGUI objectiveText; // Reference to the TextMeshProUGUI component
    public KeyCode showObjectiveKey = KeyCode.Z; // Key to show the objective
    private string currentObjective;
    private bool isObjectiveVisible;
    private Coroutine currentCoroutine;

    void Start()
    {
        // Ensure the objective panel and text are hidden at the start
        objectivePanel.SetActive(false);
        isObjectiveVisible = false;
    }

    void Update()
    {
        // Check if the player presses the key to show the objective
        if (Input.GetKeyDown(showObjectiveKey))
        {
            ToggleObjective(20f); // Show objective for 20 seconds when the player presses 'Z'
        }
    }

    public void SetObjective(string newObjective)
    {
        currentObjective = newObjective;
        objectiveText.text = currentObjective;
        ShowObjective(10f); // Show objective for 10 seconds by default
    }

    public void ShowObjective(float duration)
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine); // Stop any existing coroutine
        }
        currentCoroutine = StartCoroutine(ShowObjectiveCoroutine(duration));
    }

    public void HideObjective()
    {
        objectivePanel.SetActive(false);
        isObjectiveVisible = false;
    }

    public void ToggleObjective(float duration)
    {
        if (isObjectiveVisible)
        {
            HideObjective();
        }
        else
        {
            ShowObjective(duration);
        }
    }

    private IEnumerator ShowObjectiveCoroutine(float duration)
    {
        objectivePanel.SetActive(true);
        isObjectiveVisible = true;
        yield return new WaitForSeconds(duration);
        HideObjective();
    }
}
