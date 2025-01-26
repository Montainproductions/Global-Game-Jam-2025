using Unity.VisualScripting;
using UnityEngine;

public class Sc_Audio : MonoBehaviour
{
    public static Sc_Audio instance { get; private set; }

    [SerializeField]
    private AudioSource playerAudio;
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

    public void PlayPlayerAudioOneShot(AudioClip clip)
    {
        if (!playerAudio.isPlaying)
        {
            playerAudio.PlayOneShot(clip);
        }
    }

    public void StopPlayerAudio()
    {
        playerAudio.Stop();
    }
}
