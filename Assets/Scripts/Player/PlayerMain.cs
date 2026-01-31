using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public PlayerMovement Movement;
    public PlayerInputs Input;
    public PlayerInteract Interact;
    public PlayerInventory Inventory;
    public PlayerMask Mask;
    public PlayerSound Sound;

    public bool PlayerDesactivateByUIZoomIn;
    public bool PlayerDesactivate;
    
    private void Awake()
    {
        if (Movement == null) Movement = GetComposantFromGameObject<PlayerMovement>.TryGetComposant<PlayerMovement>(gameObject);
        if (Input == null) Input = GetComposantFromGameObject<PlayerInputs>.TryGetComposant<PlayerInputs>(gameObject);
        if (Interact == null) Interact = GetComposantFromGameObject<PlayerInteract>.TryGetComposant<PlayerInteract>(gameObject);
        if (Inventory == null) Inventory = GetComposantFromGameObject<PlayerInventory>.TryGetComposant<PlayerInventory>(gameObject);
        if (Mask == null) Mask = GetComposantFromGameObject<PlayerMask>.TryGetComposant<PlayerMask>(gameObject);
        if (Sound == null) Sound = GetComposantFromGameObject<PlayerSound>.TryGetComposant<PlayerSound>(gameObject);

        Movement.Init(this);
        Input.Init(this);
        Interact.Init(this);
        Inventory.Init(this);
        Mask.Init(this);
        Sound.Init(this);
    }

    public void DesactivatePlayer(bool fromUIZoomIn)
    {
        PlayerDesactivate = true;
        if (fromUIZoomIn)
        {
            PlayerDesactivateByUIZoomIn = true;
            GameManager.Instance.UI.PlayerAim.SetActive(false);
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Movement.StopPlayer();
    }

    public void ActivatePlayer()
    {
        PlayerDesactivateByUIZoomIn = false;
        PlayerDesactivate = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameManager.Instance.UI.PlayerAim.SetActive(true);
    }
}