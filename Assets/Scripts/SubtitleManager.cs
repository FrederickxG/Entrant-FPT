using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubtitleManager : MonoBehaviour
{
    public TextMeshProUGUI subtitleText; 
    public float displayDuration = 5f; // How long each subtitle is displayed

    public float xOffset = 0f; // Offset for horizontal positioning

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

        // Get the screen height and width
        float screenHeight = Screen.height;
        float screenWidth = Screen.width;

        // Calculate the Y position for centering at the bottom of the screen
        float bottomY = screenHeight * -0.45f; 

        // Calculate the X position with the xOffset
        float centerX = screenWidth * 0.2f; // Center of the screen
        float xPos = centerX + xOffset;

        // Set the anchored position of the subtitle text
        subtitleText.rectTransform.anchoredPosition = new Vector2(xPos, bottomY);

        yield return new WaitForSeconds(displayDuration);
        subtitleText.gameObject.SetActive(false);
    }
}
