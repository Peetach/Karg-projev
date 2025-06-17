using UnityEngine;

public class backMusic : MonoBehaviour
{
    public AudioClip musicClip;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.volume = 1; // Optional: adjust volume
        audioSource.Play();
    }
}
