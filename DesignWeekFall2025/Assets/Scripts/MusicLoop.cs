using UnityEngine;

public class MusicLoop : MonoBehaviour
{
    public AudioClip[] musicClip;
    public AudioSource audioSource;
    void Start()
    {
        audioSource.Play();
        audioSource.clip = musicClip[0];
    }

    void Update()
    {
        if (!audioSource.isPlaying) 
        {
            audioSource.Play();
            audioSource.clip = musicClip[1];
        }
    }
}
