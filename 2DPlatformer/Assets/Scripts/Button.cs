using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Button : MonoBehaviour
{
    [SerializeField] private Door _connectedDoor;
    [SerializeField] private ButtonPressurePart _pressurePart;
    [SerializeField] private SpriteRenderer _staticPart;

    private readonly int PressTrigger = Animator.StringToHash("Pressing");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _staticPart.color = _connectedDoor.GetColor();
    }

    private void OnEnable()
    {
        _pressurePart.Pressing += OnPress;
    }

    private void OnDisable()
    {
        _pressurePart.Pressing -= OnPress;
    }

    private void OnPress()
    {
        _animator.SetTrigger(PressTrigger);
        _connectedDoor.Open();
    }
}