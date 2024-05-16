using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubtitleManager : MonoBehaviour
{
    public TextMeshProUGUI subtitleText; 
    public float displayDuration = 5f; // How long each subtitle is displayed

    private Coroutine currentSubtitleCoroutine;

    // Call this method to display a subtitle
    public void ShowSubtitle(string subtitle)
    {
        if (currentSubtitleCoroutine != null)
        {
            StopCoroutine(currentSubtitleCoroutine);
        }
        currentSubtitleCoroutine = StartCoroutine(DisplaySubtitle(subtitle));
    }

    private IEnumerator DisplaySubtitle(string subtitle)
    {
        subtitleText.text = subtitle;
        subtitleText.gameObject.SetActive(true);
        yield return new WaitForSeconds(displayDuration);
        subtitleText.gameObject.SetActive(false);
    }
}
