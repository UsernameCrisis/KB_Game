using UnityEngine;
using System.Collections;

public class MusicFader : MonoBehaviour
{
    public AudioSource audioSource;
    public float fadeDuration = 2f;

    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume; // reset for next time
    }
}
