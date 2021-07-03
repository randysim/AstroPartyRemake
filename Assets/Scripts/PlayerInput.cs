using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerController player;
    
    [SerializeField] private KeyCode leftKeyCode;
    [SerializeField] private KeyCode rightKeyCode;
    [SerializeField] private KeyCode forwardKeyCode;


    private bool isLeft = false;
    private bool isRight = false;
    private bool isForward = false;

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
