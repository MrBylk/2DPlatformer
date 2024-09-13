using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SlimeMovement : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 100f;

    private float _jumpDelay = 2.0f;
    private Vector2 _direction;
    private Rigidbody2D _rigidbody;
    private bool _isWork = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _direction = new Vector2(1, 1);
    }

    private void Start()
    {
        StartCoroutine(Jump());
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Waypoint>(out _))
        {
            ChangeDirection();
        }
    }

    private IEnumerator Jump()
    {
        var wait = new WaitForSeconds(_jumpDelay);

        while (_isWork)
        {
            _rigidbody.AddForce(new Vector2(_jumpForce, _jumpForce) * _direction);
            yield return wait;
        }
    }

    private void ChangeDirection()
    {
        _direction.x *= -1;
    }
}