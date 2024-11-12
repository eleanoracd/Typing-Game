using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip correctSFX;
    [SerializeField] private AudioClip incorrectSFX;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCorrectSFX()
    {
        audioSource.PlayOneShot(correctSFX);
    }

    public void PlayIncorrectSFX()
    {
        audioSource.PlayOneShot(incorrectSFX);
    }
}
