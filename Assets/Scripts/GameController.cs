using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoSingleton<GameController>
{
    [Header("Pong Game Objects")]
    public BallController Ball;
    public PaddleController PlayerPaddle;
    public PaddleController AIPaddle;

    [Header("Score Objects")]
    [SerializeField] private Text _playerScoreText;
    [SerializeField] private Text _aiScoreText;
    [SerializeField] private int _winningScore = 5;

    [Header("Final Score Objects")]
    [SerializeField] private GameObject _finalScreen;
    [SerializeField] private Text _scoreText;

    private int _playerScore = 0;
    private int _aiScore = 0;

    private void Start()
    {
        ResetGame();
    }

    private void Update()
    {
        if (_playerScore >= _winningScore || _aiScore >= _winningScore)
        {
            EndGame();
        }
        if (Input.GetKeyDown(KeyCode.R) && _finalScreen.activeSelf) 
        {
            ResetGame();
        }
    }

    public void PlayerScores()
    {
        _playerScore++;
        UpdateScore();
        ResetRound();
    }

    public void AIScores()
    {
        _aiScore++;
        UpdateScore();
        ResetRound();
    }

    private void UpdateScore()
    {
        _playerScoreText.text = _playerScore.ToString();
        _aiScoreText.text = _aiScore.ToString();
    }

    private void ResetGame()
    {
        _finalScreen.SetActive(false); 

        _playerScore = 0;
        _aiScore = 0;
        UpdateScore();
        ResetRound();
    }

    private void ResetRound()
    {
        Ball.ResetBall();
        PlayerPaddle.ResetPaddle();
        AIPaddle.ResetPaddle();
    }

    private void EndGame()
    {
        ResetRound();

        _scoreText.text = $"Player: {_playerScore} - AI: {_aiScore}\n" +
                          $"Press 'R' to restart game.";

        _finalScreen.SetActive(true);
    }
}