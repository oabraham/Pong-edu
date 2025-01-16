using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public int player1Score = 0;
    public int player2Score = 0;

    private Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    public void UpdateScore(int player)
    {
        if (player == 1)
        {
            player1Score++;
        }
        else if (player == 2)
        {
            player2Score++;
        }

        scoreText.text = player1Score + " - " + player2Score;
    }
}
