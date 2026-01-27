using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public PlayerMovement Movement;
    public PlayerInputs Input;
    public PlayerInteract Interact;
    public PlayerInventory Inventory;
    public PlayerMask Mask;

    private void Awake()
    {
        if (Movement == null) Movement = GetComposantFromGameObject<PlayerMovement>.TryGetComposant<PlayerMovement>(gameObject);
        if (Input == null) Input = GetComposantFromGameObject<PlayerInputs>.TryGetComposant<PlayerInputs>(gameObject);
        if (Interact == null) Interact = GetComposantFromGameObject<PlayerInteract>.TryGetComposant<PlayerInteract>(gameObject);
        if (Inventory == null) Inventory = GetComposantFromGameObject<PlayerInventory>.TryGetComposant<PlayerInventory>(gameObject);
        if (Mask == null) Mask = GetComposantFromGameObject<PlayerMask>.TryGetComposant<PlayerMask>(gameObject);

        Movement.Init(this);
        Input.Init(this);
        Interact.Init(this);
        Inventory.Init(this);
        Mask.Init(this);
    }
}