using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayRandomSFX : MonoBehaviour
{
    public bool playOnStart = true;

    public AudioClip[] audioClipsToPlay;

    public AudioSource _audioSource;

    private void Start()
    {
        if (playOnStart)
        {
            PlaySFX();
        }
    }

    public void PlaySFX()
    {
        _audioSource.clip = audioClipsToPlay[Random.Range(0, audioClipsToPlay.Length)];
        _audioSource.Play();
    }
}
