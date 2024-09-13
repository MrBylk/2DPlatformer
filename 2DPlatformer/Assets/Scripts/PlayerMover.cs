using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D), typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private float _jumpPower = 7.0f;
    [SerializeField] private InputReader _inputReader;

    private readonly int WalkTriggerName = Animator.StringToHash("IsWalking");
    private SpriteRenderer _renderer;
    private Rigidbody2D _rigidbody;
    private bool _isJump;
    private RaycastHit2D _hit;
    private Animator _animator;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _inputReader.KeyAPressed += MoveLeft;
        _inputReader.KeyDPressed += MoveRight;
        _inputReader.KeySpacePressed += TryJump;
        _inputReader.MoveKeysUnpressed += StopWalkAnimation;
    }

    private void OnDisable()
    {
        _inputReader.KeyAPressed -= MoveLeft;
        _inputReader.KeyDPressed -= MoveRight;
        _inputReader.KeySpacePressed -= TryJump;
        _inputReader.MoveKeysUnpressed -= StopWalkAnimation;
    }

    private void FixedUpdate()
    {
        if (_isJump)
        {
            _rigidbody.velocity = Vector2.up * _jumpPower;
            _isJump = false;
        }
    }

    private void MoveLeft()
    {
        transform.Translate(new Vector3(-_speed, 0, 0) * Time.deltaTime);
        _renderer.flipX = true;
        _animator.SetBool(WalkTriggerName, true);
    }

    private void MoveRight()
    {
        transform.Translate(new Vector3(_speed, 0, 0) * Time.deltaTime);
        _renderer.flipX = false;
        _animator.SetBool(WalkTriggerName, true);
    }

    private void TryJump()
    {
        _hit = Physics2D.Raycast(transform.position, Vector2.down, transform.localScale.y);

        if (_hit.transform != null)
        {
            if (_hit.transform.TryGetComponent<Ground>(out _))
            {
                _isJump = true;
            }
        }
    }

    private void StopWalkAnimation()
    {
        _animator.SetBool(WalkTriggerName, false);
    }
}