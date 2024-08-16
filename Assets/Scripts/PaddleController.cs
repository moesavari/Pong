using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private bool _isPlayer = false;
    [SerializeField] private Rigidbody2D _rigidbody;

    void Update()
    {
        if (_isPlayer)
        {
            float verticalInput = Input.GetAxis("Vertical");
            _rigidbody.velocity = new Vector2(0, verticalInput * _speed);
        }
        else
        {
            _rigidbody.velocity = new Vector2(0, transform.position.y < GameController.Instance.Ball.transform.position.y ? _speed : -_speed);
        }
    }

    public void ResetPaddle()
    {
        _rigidbody.velocity = Vector2.zero;
        transform.position = new Vector2(transform.position.x, 0);
    }
}