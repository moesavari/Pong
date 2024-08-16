using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoSingleton<GameController>
{
    public BallController Ball;
    public PaddleController PlayerPaddle;
    public PaddleController AIPaddle;

    [SerializeField] private Text _playerScoreText;
    [SerializeField] private Text _aiScoreText;
    [SerializeField] private int _winningScore = 5;

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
        // Add game over logic here
    }
}