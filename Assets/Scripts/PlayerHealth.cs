using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 4;
    public int explosionRadius = 4;
    public int explosionForce = 5;
    [SerializeField] private GameObject explosion;
    [SerializeField] private LayerMask playerLayer;
    private int currentHealth;

    private bool blinking = false;
    private SpriteRenderer playerSprite;

    private void Start()
    {
        GameManager.INSTANCE.addPlayer(gameObject);
        currentHealth = maxHealth;
        playerSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (blinking)
        {
            StartCoroutine(Blink());
        }
    }

    private IEnumerator Blink ()
    {

        playerSprite.color = new Color(1, 1, 1, 0);

        int blinkCount = 4;

        for (int i = 0; i < blinkCount; ++i)
        {
            if (i % 2 == 0)
            {
                playerSprite.color = new Color(1, 1, 1, 1);
            } else
            {
                playerSprite.color = new Color(1, 1, 1, 0);
            }

            yield return new WaitForSeconds(0.05f);
        }
        

        playerSprite.color = new Color(1, 1, 1, 1);

        blinking = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("Bullet"))
        {
            currentHealth--;

            if (currentHealth <= 0)
            {
                playerDeath();
            } else
            {
                blinking = true;
            }
        }
    }

    private void playerDeath ()
    {
        
        Collider2D[] playersAffected = Physics2D.OverlapCircleAll(transform.position, explosionRadius, playerLayer);
        foreach (Collider2D player in playersAffected)
        {
            Vector2 direction = player.transform.position - transform.position;
            player.GetComponent<Rigidbody2D>().AddForce(direction * explosionForce, ForceMode2D.Impulse);
        }

        GameObject explosionRef = Instantiate(explosion, transform.position, Quaternion.identity); // Quaternion.identity = no rotation
        Destroy(explosionRef, 10f);
        Destroy(gameObject);
        GameManager.INSTANCE.OnPlayerDeath(gameObject);
    }

    // DEBUG: Shows only in Editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    /* HEALTH PROPERTY */
    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }
}
