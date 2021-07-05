using UnityEngine;

public class ExplosionSound : MonoBehaviour
{
    [SerializeField] private AudioClip explosionSound;
    private AudioSource audioSource;
    void Start()
    {
        audioSource.clip = explosionSound;
        audioSource.Play();
    }
}
