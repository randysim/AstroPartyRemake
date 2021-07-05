using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    [SerializeField] private AudioClip laser;
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        audioSource.clip = laser;
        audioSource.Play();
    }
}
