using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public PlayerBase player1Base;
    public PlayerBase player2Base;
    public PlayerBase player3Base;
    public PlayerBase player4Base;

    // Ui Player Score Text
    public Text player1Score;
    public Text player2Score;
    public Text player3Score;
    public Text player4Score;

    // Sign up playerbases with UI score
    void Start()
    {
        player1Base.OnPlayerScoreHandler += UpdateUI;
        player2Base.OnPlayerScoreHandler += UpdateUI;
        player3Base.OnPlayerScoreHandler += UpdateUI;
        player4Base.OnPlayerScoreHandler += UpdateUI;
    }

    public void UpdateUI(int playerId, int score)
    {
        switch (playerId)
        {
            case 1:
                player1Score.text = score.ToString();
                break;
            case 2:
                player2Score.text = score.ToString();
                break;
            case 3:
                player3Score.text = score.ToString();
                break;
            case 4:
                player4Score.text = score.ToString();
                break;
        }
    }

}
