using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private Rigidbody2D _rigidbody;

    private GameController _gameController;

    private void Start()
    {
        _gameController = GameController.Instance;
        ResetBall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Paddle"))
        {
            Vector2 direction = transform.position - collision.collider.transform.position;
            _rigidbody.velocity = direction.normalized * _speed;
        }

        if (collision.collider.CompareTag("LeftWall"))
        {
            _gameController.AIScores();
        }
        else if (collision.collider.CompareTag("RightWall"))
        {
            _gameController.PlayerScores();
        }
    }

    public void ResetBall()
    {
        _rigidbody.velocity = Vector2.zero;
        transform.position = Vector2.zero;

        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        Vector2 initialDirection = new Vector2(randomX, randomY).normalized;
        _rigidbody.velocity = initialDirection * _speed;
    }
}