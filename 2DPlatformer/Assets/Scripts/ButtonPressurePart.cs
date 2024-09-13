using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class ButtonPressurePart : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private Color _pressedColor;
    private Color _notPressedColor;

    public event UnityAction Pressing;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _pressedColor = Color.green;
        _notPressedColor = Color.red;
        _renderer.color = _notPressedColor;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<PlayerMover>(out _) || collision.transform.TryGetComponent<Ball>(out _))
        {
            Pressing?.Invoke();
            _renderer.color = _pressedColor;
        }
    }
}