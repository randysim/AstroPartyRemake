using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 4;

    private bool blinking = false;
    private SpriteRenderer playerSprite;

    private void Start()
    {
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
            maxHealth--;

            if (maxHealth <= 0)
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
        Destroy(gameObject);
    }
}
