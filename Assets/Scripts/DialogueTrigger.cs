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
    public GameObject Adrikvill;
    public GameObject FreyaAsyl;
    public GameObject AdrikAsyl;

    private bool dialogue1Triggered = false;
    private bool dialogue2Triggered = false;
    private bool dialogue3Triggered = false;
    private bool dialogue4Triggered = false;
    private bool dialogue5Triggered = false;
    private bool dialogue6Triggered = false;
    private bool dialogue7Triggered = false;

    private void Start()
    {
        StartCoroutine(StartDialogueSequenceWithDelay());
    }

    private IEnumerator StartDialogueSequenceWithDelay()
    {
        yield return new WaitForSeconds(dialogueStartDelay);

        // Check conditions for DialogueSequence1, DialogueSequence2, DialogueSequence3, DialogueSequence4, DialogueSequence5
        if (freyaOmanr != null)
            StartCoroutine(CheckDialogueSequence1Conditions());

        if (freyaWmanor != null)
            StartCoroutine(CheckDialogueSequence2Conditions());

        if (freyaCene != null)
            StartCoroutine(CheckDialogueSequence3Conditions());

        if (freyaOvill != null)
            StartCoroutine(CheckDialogueSequence4Conditions());

        if (Adrikvill != null)
            StartCoroutine(CheckDialogueSequence5Conditions());

        if (FreyaAsyl != null)
            StartCoroutine(CheckDialogueSequence6Conditions());

        if (AdrikAsyl != null)
            StartCoroutine(CheckDialogueSequence7Conditions());
          
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

    private IEnumerator CheckDialogueSequence5Conditions()
    {
        while (!dialogue5Triggered)
        {
            if (Adrikvill.activeSelf)
            {
                yield return StartCoroutine(DialogueSequence5());
                dialogue5Triggered = true;
            }
            yield return null;
        }
    }

    private IEnumerator CheckDialogueSequence6Conditions()
    {
        while (!dialogue6Triggered)
        {
            if (FreyaAsyl.activeSelf)
            {
                yield return StartCoroutine(DialogueSequence6());
                dialogue6Triggered = true;
            }
            yield return null;
        }
    }

     private IEnumerator CheckDialogueSequence7Conditions()
    {
        while (!dialogue7Triggered)
        {
            if (AdrikAsyl.activeSelf)
            {
                yield return StartCoroutine(DialogueSequence7());
                dialogue7Triggered = true;
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
        }, new float[] { 1.8f, 2.5f, 3f });
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
        }, new float[] { 1.6f, 1.8f, 2f, 1.5f, 1.4f, 1.7f, 1.8f });
    }

    private IEnumerator DialogueSequence3()
    {
        yield return ShowDialogue(new string[]
        {
            "Ato- alright Freya, what you got? ",
            "Freya- well according to my database vantage ",
            "Freya- is a small village on the outskirts of Svyataya",
            "Freya- the town stayed under the radar for the entirety of its existence",
            "Freya- but I guess we can add a new entry to the history books",
            "Freya- by the way it would help if you took some pictures while you're there",
            "Freya- I started a scrapbook for our explorations",
            "Ato- a scrapbook huh? that's uh unique I guess"
        }, new float[] { 1.7f, 2.2f, 4.2f, 2.9f, 3.6f, 4.5f, 2.8f, 3.3f});
    }

    private IEnumerator DialogueSequence4()
    {
        yield return ShowDialogue(new string[]
        {
            "Freya- so this vantage huh? pretty underwhelming if you ask me",
            "Freya- but find Adrik’s house and while you're at it ",
            "Freya- you should check out the rent",
            "Ato- you know that's actually a pretty good idea but", 
            "Ato- there's just something about the bronx rats that are just so charming", 
        }, new float[] { 4f, 3.1f, 1.8f, 2.8f, 1.2f });
    }

    private IEnumerator DialogueSequence5()
    {
        yield return ShowDialogue(new string[]
        {
            "*knock knock knock*",
            "Adrik- I wasn't expecting any visitors",
            "Ato- You know after knock knock they typically say whose there",
            "Adrik- okay who was there?",
            "Ato- ye- yeah i dont think that's how it=-", 
        }, new float[] { 1.4f, 2.5f, 2.8f, 2.4f, 2.8f});
    }

    private IEnumerator DialogueSequence6()
    {
        yield return ShowDialogue(new string[]
        {
            "Freya- well you surely won't get the early bird award",
            "Ato- haha, th-that’s a good one Freya where am I?",
            "Freya- based on my scans you are in some abandoned asylum however",
            "Freya- there's an exit very close so chop-chop if you want that worm",
            "Ato- yea I- I think I’ll pass ", 
        }, new float[] { 1.4f, 2.5f, 2.8f, 2.4f, 2.8f});
    }

      private IEnumerator DialogueSequence7()
    {
        yield return ShowDialogue(new string[]
        {
            "Ato- Robert Thompson, poor guy",
            "Adrik- you should worry about yourself",
            "Ato- hm?",
        }, new float[] { 1.4f, 2.5f, 2.8f});
    }

    private IEnumerator ShowDialogue(string[] dialogues, float[] displayDurations)
    {
        for (int i = 0; i < dialogues.Length; i++)
        {
            subtitleManager.ShowSubtitle(dialogues[i]);
            yield return new WaitForSeconds(displayDurations[i]);
        }
    }
}
