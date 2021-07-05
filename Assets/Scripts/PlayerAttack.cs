using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private KeyCode attackKey;
    [SerializeField] private float attackCooldown = 1f; // in seconds
    [SerializeField] private float bulletSpeed = 300;
    [SerializeField] private GameObject bulletPrefab;

    private bool attacking = false;
    private float lastAttack = 0;

    // Update is called once per frame
    void Update()
    {
        attacking = Input.GetKey(attackKey);
    }

    private void FixedUpdate()
    {
        lastAttack += Time.deltaTime;

        if (lastAttack >= attackCooldown && attacking)
        {
            attack(Time.deltaTime);
            lastAttack = 0;
        }
    }

    private void attack (float deltaTime)
    {
        Quaternion playerRotation = transform.rotation;
        Vector3 playerPos = transform.position;
        Vector3 playerDirection = transform.TransformDirection(Vector2.up);
        Vector3 spawnPos = playerPos + (-playerDirection);

        GameObject bullet = Instantiate(bulletPrefab, spawnPos, playerRotation);
        Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
        bulletBody.AddRelativeForce(new Vector2(0, -bulletSpeed * deltaTime), ForceMode2D.Impulse);
    }
}
