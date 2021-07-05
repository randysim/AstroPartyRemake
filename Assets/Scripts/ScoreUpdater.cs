using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    public Text component;

    private void Start()
    {
        component = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        component.text = GameManager.INSTANCE.playerOneScore + ":" + GameManager.INSTANCE.playerTwoScore;
    }
}
