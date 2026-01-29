using UnityEngine;

public class InteractableWithAnim : Interactable
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public override void GetInteract(PlayerMain player)
    {
        base.GetInteract(player);
        if (_isLocked) return;
        _animator.SetTrigger("Interact");
    }
}