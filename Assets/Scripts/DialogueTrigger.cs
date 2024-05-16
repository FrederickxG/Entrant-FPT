using System.Collections;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public SubtitleManager subtitleManager;
    public float dialogueStartDelay = 3f;
    public GameObject freyaOmanr;
    public GameObject freyaWmanor;

    private bool dialogue2Triggered = false;

    private void Start()
    {
        StartCoroutine(StartDialogueSequenceWithDelay());
    }

    private IEnumerator StartDialogueSequenceWithDelay()
    {
        yield return new WaitForSeconds(dialogueStartDelay);

        StartCoroutine(DialogueSequence1());
    }

    private IEnumerator DialogueSequence1()
    {
        // Set the displayDuration for DialogueSequence1
        subtitleManager.displayDuration = 2f;

        subtitleManager.ShowSubtitle("There's a clipboard somewhere here");
        yield return new WaitForSeconds(subtitleManager.displayDuration); // Wait for the display duration + some padding

        subtitleManager.ShowSubtitle("If I had to guess it'd be in that castle");
        yield return new WaitForSeconds(subtitleManager.displayDuration);

        subtitleManager.ShowSubtitle("Although maybe bringing a shovel would've faired better");
        yield return new WaitForSeconds(subtitleManager.displayDuration);

        // After DialogueSequence1, check conditions for DialogueSequence2
        StartCoroutine(CheckDialogueSequence2Conditions());
    }

    private IEnumerator CheckDialogueSequence2Conditions()
    {
        // Check conditions for dialogue sequence 2
        while (!dialogue2Triggered) // Run the check continuously until dialogue2Triggered becomes true
        {
            if (freyaWmanor.activeSelf)
            {
                StartCoroutine(DialogueSequence2());
                dialogue2Triggered = true; // Set a flag to prevent repeated triggering
            }
            yield return null; // Wait for the next frame before checking conditions again
        }
    }

    private IEnumerator DialogueSequence2()
    {
        // Set the displayDuration for DialogueSequence2
        subtitleManager.displayDuration = 1.4f;

        subtitleManager.ShowSubtitle(" hm?");
        yield return new WaitForSeconds(subtitleManager.displayDuration); // Wait for the display duration + some padding

        subtitleManager.ShowSubtitle("I’d advise you to take a few steps back");
        yield return new WaitForSeconds(subtitleManager.displayDuration);

        subtitleManager.ShowSubtitle("unless you wish to fail humanity");
        yield return new WaitForSeconds(subtitleManager.displayDuration);
    }
}
