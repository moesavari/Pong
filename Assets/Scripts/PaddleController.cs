using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _verticalBounds = 4.5f;
    [SerializeField] private float _aiSmoothTime = 0.1f; // Smooth time for AI movement

    [SerializeField] private bool _isPlayer = false;
    [SerializeField] private Rigidbody2D _rigidbody;

    private float _currentYVelocity = 0f; // Used for smoothing AI movement

    void Update()
    {
        if (_isPlayer)
        {
            float verticalInput = Input.GetAxis("Vertical");
            _rigidbody.velocity = new Vector2(0, verticalInput * _speed);
        }
        else
        {
            float targetY = GameController.Instance.Ball.transform.position.y;
            float smoothY = Mathf.SmoothDamp(transform.position.y, targetY, ref _currentYVelocity, _aiSmoothTime, _speed, Time.deltaTime);

            float desiredVelocity = (smoothY - transform.position.y) / Time.deltaTime;

            // Clamp the AI paddle's velocity to ensure it does not exceed max speed
            float clampedVelocity = Mathf.Clamp(desiredVelocity, -_speed, _speed);
            _rigidbody.velocity = new Vector2(0, clampedVelocity);

            _rigidbody.velocity = new Vector2(0, (smoothY - transform.position.y) / Time.deltaTime);
        }

        float clampedY = Mathf.Clamp(transform.position.y, -_verticalBounds, _verticalBounds);
        transform.position = new Vector2(transform.position.x, clampedY);
    }

    public void ResetPaddle()
    {
        _rigidbody.velocity = Vector2.zero;
        transform.position = new Vector2(transform.position.x, 0);
    }
}