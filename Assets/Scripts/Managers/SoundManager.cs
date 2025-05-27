using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource mainThemeAudioSource;
    public AudioClip audioClipMainTheme;
    public AudioClip audioClipClick;
    public AudioClip audioClipDie;
    public AudioClip audioClipFire;
    public AudioClip audioClipHit;

    public static SoundManager Instance;

    void Awake()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (SoundManager.Instance == null)
        {
            SoundManager.Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void PlayMainTheme()
    {
        if (audioClipMainTheme != null)
        {
            mainThemeAudioSource.clip = audioClipMainTheme;
            mainThemeAudioSource.loop = true;
            mainThemeAudioSource.Play();
        }
    }
    public void PlayClickSound()
    {
        if (audioClipClick != null)
        {
            audioSource.PlayOneShot(audioClipClick);
        }
    }
    public void PlayDieSound()
    {
        if (audioClipDie != null)
        {
            audioSource.PlayOneShot(audioClipDie);
        }
    }
    public void PlayFireSound()
    {
        if (audioClipFire != null)
        {
            audioSource.PlayOneShot(audioClipFire);
        }
    }
    public void PlayHitSound()
    {
        if (audioClipHit != null)
        {
            audioSource.PlayOneShot(audioClipHit);
        }
    }
    public void StopAllSounds()
    {
        audioSource.Stop();
        mainThemeAudioSource.Stop();
    }
}
