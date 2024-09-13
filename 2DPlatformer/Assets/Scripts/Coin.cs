using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Coin : MonoBehaviour
{
    private readonly int CollectTrigger = Animator.StringToHash("Collected");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Collect()
    {
        _animator.SetTrigger(CollectTrigger);
    }
}