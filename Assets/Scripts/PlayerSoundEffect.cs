using UnityEngine;

public class PlayerSoundEffect : MonoBehaviour
{
    [SerializeField] private AudioClip onHit;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (audioSource && collision.gameObject.name.StartsWith("Bullet"))
        {
            audioSource.clip = onHit;
            audioSource.Play();
        }
    }
}
