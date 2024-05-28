using System.Collections;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public SubtitleManager subtitleManager;
    public float dialogueStartDelay = 3f;
    public GameObject freyaOmanr;
    public GameObject freyaWmanor;
    public GameObject freyaCene;
    public GameObject freyaOvill;

    private bool dialogue1Triggered = false;
    private bool dialogue2Triggered = false;
    private bool dialogue3Triggered = false;
    private bool dialogue4Triggered = false;

    private void Start()
    {
        StartCoroutine(StartDialogueSequenceWithDelay());
    }

    private IEnumerator StartDialogueSequenceWithDelay()
    {
        yield return new WaitForSeconds(dialogueStartDelay);

        // Check conditions for DialogueSequence1, DialogueSequence2, and DialogueSequence3
        if (freyaOmanr != null)
            StartCoroutine(CheckDialogueSequence1Conditions());

        if (freyaWmanor != null)
            StartCoroutine(CheckDialogueSequence2Conditions());

        if (freyaCene != null)
            StartCoroutine(CheckDialogueSequence3Conditions());

        if (freyaOvill!= null)
            StartCoroutine(CheckDialogueSequence4Conditions());
    }

    private IEnumerator CheckDialogueSequence1Conditions()
    {
        while (!dialogue1Triggered)
        {
            if (freyaOmanr.activeSelf)
            {
                yield return StartCoroutine(DialogueSequence1());
                dialogue1Triggered = true;
            }
            yield return null;
        }
    }

    private IEnumerator CheckDialogueSequence2Conditions()
    {
        while (!dialogue2Triggered)
        {
            if (freyaWmanor.activeSelf)
            {
                yield return StartCoroutine(DialogueSequence2());
                dialogue2Triggered = true;
            }
            yield return null;
        }
    }

    private IEnumerator CheckDialogueSequence3Conditions()
    {
        while (!dialogue3Triggered)
        {
            if (freyaCene.activeSelf)
            {
                yield return StartCoroutine(DialogueSequence3());
                dialogue3Triggered = true;
            }
            yield return null;
        }
    }

     private IEnumerator CheckDialogueSequence4Conditions()
    {
        while (!dialogue4Triggered)
        {
            if (freyaOvill.activeSelf)
            {
                yield return StartCoroutine(DialogueSequence4());
                dialogue4Triggered = true;
            }
            yield return null;
        }
    }

    private IEnumerator DialogueSequence1()
    {
        yield return ShowDialogue(new string[]
        {
            "Freya- There's a clipboard somewhere here",
            "Freya- If I had to guess it'd be in that castle",
            "Freya- Although maybe bringing a shovel would've faired better"
        }, 2f);
    }

    private IEnumerator DialogueSequence2()
    {
        yield return ShowDialogue(new string[]
        {
            "Freya- hm?",
            "Freya- I’d advise you to take a few steps back",
            "Freya- unless you wish to fail humanity",
            "Ato- Yea",
            "Ato- it's not like I don't wanna die in general",
            "Ato- but you know, for humanity",
            "Ato- Am I right?"
        }, 1.6f);
    }

    private IEnumerator DialogueSequence3()
    {
        yield return ShowDialogue(new string[]
        {
            "Ato- alright, Freya hit me ",
            "Freya- well according to my database vantage ",
            "Freya- is a small village on the outskirts of Svyataya",
            "Freya- the town stayed under the radar", 
            "Freya- for the entirety of its existence", 
            "Freya-  but I guess we can add",
            "Freya- a new entry to the history books",
            "Freya- by the way it would help if you took some pictures while you're there",
            "Freya- I started a scrapbook for our explorations",
            "Ato- a scrapbook well   your interesting freya"
        }, 2f);
    }

    private IEnumerator DialogueSequence4()
    {
        yield return ShowDialogue(new string[]
        {
            "Freya- so this vantage huh?  pretty underwhelming if you ask me",
            "Freya- but find Adrik’s house and while you're at it ",
            "Freya-  you should check out the rent",
            "Ato- you know that's a great idea but", 
            "Ato- there's just something about the bronx rats", 
            "Ato- that is so charming", 
        }, 4f);
    }

    private IEnumerator ShowDialogue(string[] dialogues, float displayDuration)
    {
        subtitleManager.displayDuration = displayDuration;

        foreach (var dialogue in dialogues)
        {
            subtitleManager.ShowSubtitle(dialogue);
            yield return new WaitForSeconds(displayDuration);
        }
    }
}
