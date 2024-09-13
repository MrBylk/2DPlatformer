    using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    [SerializeField] private Color _color;
    [SerializeField] private SpriteRenderer _part1;
    [SerializeField] private SpriteRenderer _part2;

    private readonly int OpenTrigger = Animator.StringToHash("Open");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _part1.color = _color;
        _part2.color = _color;
    }

    public Color GetColor()
    {
        return _color;
    }

    public void Open()
    {
        _animator.SetTrigger(OpenTrigger);
    }
}