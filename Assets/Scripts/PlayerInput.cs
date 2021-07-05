using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerController player;
    
    private KeyCode leftKeyCode;
    private KeyCode rightKeyCode;
    private KeyCode forwardKeyCode;


    private bool isLeft = false;
    private bool isRight = false;
    private bool isForward = false;

    private void Start()
    {
        if (GameManager.INSTANCE.p1.name == gameObject.name)
        {
            leftKeyCode = KeyCode.A;
            rightKeyCode = KeyCode.D;
            forwardKeyCode = KeyCode.W;
        } else
        {
            leftKeyCode = KeyCode.LeftArrow;
            rightKeyCode = KeyCode.RightArrow;
            forwardKeyCode = KeyCode.UpArrow;
        }
    }
    void Update()
    {
        isLeft = Input.GetKey(leftKeyCode);
        isRight = Input.GetKey(rightKeyCode);
        isForward = Input.GetKey(forwardKeyCode);
    }

    private void FixedUpdate()
    {
        if (isLeft) player.moveLeft(Time.deltaTime);
        if (isRight) player.moveRight(Time.deltaTime);
        if (isForward) player.moveForward(Time.deltaTime);
    }
}
