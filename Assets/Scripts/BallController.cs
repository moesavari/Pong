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

        float angle = Random.Range(0, 45);
        float radians = angle * Mathf.Deg2Rad;
        Vector2 initialDirection = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)).normalized;

        // Randomly choose the initial direction to be left or right
        if (Random.value > 0.5f)
        {
            initialDirection.x = -initialDirection.x;
        }

        _rigidbody.velocity = initialDirection * _speed;
    }
}