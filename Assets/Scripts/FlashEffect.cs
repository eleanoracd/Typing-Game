using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlashEffect : MonoBehaviour
{
    [SerializeField] private Image flashObject;                  // Full-screen Image for flash
    [SerializeField] private Color correctColor = new Color(0, 1, 0, 0.5f);   // Green with transparency
    [SerializeField] private Color incorrectColor = new Color(1, 0, 0, 0.5f); // Red with transparency
    [SerializeField] private float flashDuration = 0.2f;

    public void PlayFlash(bool isCorrect)
    {
        Color flashColor = isCorrect ? correctColor : incorrectColor;
        StartCoroutine(FlashCoroutine(flashColor));
    }

    private IEnumerator FlashCoroutine(Color flashColor)
    {
        flashObject.color = flashColor;         // Set the color based on correct/incorrect
        flashObject.gameObject.SetActive(true); // Enable the flash object
        yield return new WaitForSeconds(flashDuration);
        flashObject.gameObject.SetActive(false); // Disable the flash object
    }
}
