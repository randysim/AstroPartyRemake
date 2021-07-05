using UnityEngine;

public class AdjustCamera : MonoBehaviour
{
    public Transform playerOne = null;
    public Transform playerTwo = null;

    private float originalSize = 0.5f;
    private Camera camRef;
   [SerializeField] private float zoomSpeed;

    private void Start()
    {
        camRef = GetComponent<Camera>();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        playerOne = players[0].transform;
        playerTwo = players[1].transform;

        originalSize = camRef.orthographicSize;
    }

    void Update()
    {
        if (!playerOne)
        {
            camRef.orthographicSize = Mathf.Lerp(camRef.orthographicSize, originalSize, Time.deltaTime * zoomSpeed);
            transform.position = Vector3.Lerp(transform.position, new Vector3(playerTwo.position.x, playerTwo.position.y, transform.position.z), Time.deltaTime * zoomSpeed);
        }
        else if (!playerTwo)
        {
            camRef.orthographicSize = Mathf.Lerp(camRef.orthographicSize, originalSize, Time.deltaTime * zoomSpeed);
            transform.position = Vector3.Lerp(transform.position, new Vector3(playerOne.position.x, playerOne.position.y, transform.position.z), Time.deltaTime * zoomSpeed);
        }
        else if (!playerOne && !playerTwo)
        {
            camRef.orthographicSize = Mathf.Lerp(camRef.orthographicSize, originalSize, Time.deltaTime * zoomSpeed);
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, 0, transform.position.z), Time.deltaTime * zoomSpeed);
        }
        else
        {

            /* CAM ZOOM LOGIC */
            float playerDistance = Mathf.Abs(Mathf.Sqrt(Mathf.Pow(playerOne.position.x - playerTwo.position.x, 2) + Mathf.Pow(playerOne.position.y - playerTwo.position.y, 2)));
            float targetSize = originalSize + (playerDistance / 2);
            camRef.orthographicSize = Mathf.Lerp(camRef.orthographicSize, targetSize, Time.deltaTime * zoomSpeed);

            /* POSITION LOGIC */
            Vector2 playerMidPoint = new Vector2(
                 playerOne.position.x + (playerTwo.position.x - playerOne.position.x) / 2,
                 playerOne.position.y + (playerTwo.position.y - playerOne.position.y) / 2
            );
            transform.position = new Vector3(playerMidPoint.x, playerMidPoint.y, transform.position.z);
        }
    }
}
