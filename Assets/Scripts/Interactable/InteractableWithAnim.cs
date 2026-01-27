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
        _animator.SetTrigger("Interact");
    }
}