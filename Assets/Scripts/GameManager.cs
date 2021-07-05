using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager INSTANCE;
    [System.NonSerialized] public int playerOneScore = 0;
    [System.NonSerialized] public int playerTwoScore = 0;

    public GameObject p1 = null;
    public GameObject p2 = null;
    
    void Awake()
    {
        if (!INSTANCE)
        {
            INSTANCE = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public void loadLocal()
    {
        playerOneScore = 0;
        playerTwoScore = 0;
        p1 = null;
        p2 = null;
        resetMainStage();
    }

    public void addPlayer (GameObject player)
    {
        if (p1 != null)
        {
            p2 = player;
        } else
        {
            p1 = player;
        }

        Debug.Log(p1);
    }

    private void resetMainStage ()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnPlayerDeath(GameObject player)
    {
        if (player.name == p1.name)
        {
            playerTwoScore++;
        } else
        {
            playerOneScore++;
        }

        Invoke("resetMainStage", 2f); // in seconds
    }

    public void loadMultiplayer ()
    {

    }
}
