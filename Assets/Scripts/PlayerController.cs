using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float turnSpeed;
    private Rigidbody2D body = null;
    

    private void Start()
    {
        body = GetRigidbody();
    }

    private Rigidbody2D GetRigidbody ()
    {
        if (body == null) body = GetComponent<Rigidbody2D>();
        return body;
    }

    public void moveLeft (float deltaTime)
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * turnSpeed));
    }
    public void moveRight(float deltaTime)
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * -turnSpeed));
    }
    public void moveForward (float deltaTime)
    {
        body.AddRelativeForce(new Vector2(0, -movementSpeed * Time.deltaTime));
    }
}
