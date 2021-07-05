using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    public bool isP1;
    private GameObject player;
    private PlayerHealth playerHealth;
    private Text component;
    private string playerName;

    private void Start()
    {
        player = isP1 ? GameManager.INSTANCE.p1 : GameManager.INSTANCE.p2;
        playerHealth = player.GetComponent<PlayerHealth>();
        component = GetComponent<Text>();
        playerName = isP1 ? "P1" : "P2";
        component.text = playerName + ": LOADING";
    }

    void Update()
    {
        if (player != null && playerHealth.CurrentHealth > 0)
        {
            component.text = playerName + ": " + playerHealth.CurrentHealth + "/" + playerHealth.maxHealth;
        } else
        {
            //component.text = playerName + ": DEAD";
        }
    }
}
