using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class Sc_Audio : MonoBehaviour
{
    public static Sc_Audio instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void PlayPlayerAudioOneShot(AudioClip clip, AudioSource audioSource)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void StopPlayerAudio(AudioSource audioSource)
    {
        audioSource.Stop();
    }
}
