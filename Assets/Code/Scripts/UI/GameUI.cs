using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameUI : MonoBehaviour
{
    public InputAction gameInstructions; // Add this to input

    public int scoreToWin = 1;

    public PlayerBase player1Base;
    public PlayerBase player2Base;
    public PlayerBase player3Base;
    public PlayerBase player4Base;

    // Ui Player Score Text
    public Text player1Score;
    public Text player2Score;
    public Text player3Score;
    public Text player4Score;

    public GameObject playerWin;
    public Text playerWinText;

    public GameObject gameInstructionText;


    private void Awake()
    {
        gameInstructions.performed += ctx => ShowHowToPlay(true);
        gameInstructions.canceled += ctx => ShowHowToPlay(false);
    }

    // Sign up playerbases with UI score
    void Start()
    {
        player1Base.OnPlayerScoreHandler += UpdateUI;
        player2Base.OnPlayerScoreHandler += UpdateUI;
        player3Base.OnPlayerScoreHandler += UpdateUI;
        player4Base.OnPlayerScoreHandler += UpdateUI;
    }

    void OnEnable()
    {
        gameInstructions.Enable();
    }

    void OnDisable()
    {
        gameInstructions.Disable();
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

        if (score >= scoreToWin)
        {
            Debug.Log("YOUWIN!! ");
            Debug.Log(playerId.ToString() + " IS WINNER");
            playerWin.SetActive(true);
            playerWinText.text = ("Player "+ playerId.ToString() + " Wins!");
        }

    }

    private void ShowHowToPlay(bool activate)
    {
        gameInstructionText.SetActive(activate);
    }

    public void ReturnToMainMenu()
    {
        // TO DO MAIN MENU
    }

    public void RestartLevel()
    {
        var _currentLevel = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(_currentLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
