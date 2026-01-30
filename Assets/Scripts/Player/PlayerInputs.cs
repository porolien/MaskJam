using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputs : MonoBehaviour
{
    public PlayerMain Main;
    private Player _inputActions;

    private InputAction _movement;
    private InputAction _look;
    private InputAction _interact;
    private InputAction _mask;
    private InputAction _escape;
    private InputAction _enterCode;

    public void Init(PlayerMain main)
    {
        Main = main;
    }
    private void Awake()
    {
        _inputActions = new Player();
        _movement = _inputActions.PlayerAction.Movement;
        _look = _inputActions.PlayerAction.Look;
        _interact = _inputActions.PlayerAction.Interact;
        _mask = _inputActions.PlayerAction.Mask;
        _escape = _inputActions.PlayerAction.Escape;
        _enterCode = _inputActions.PlayerAction.EnterCode;
    }

    private void OnEnable()
    {
        _inputActions.PlayerAction.Enable();

        _movement.performed += OnMovement;
        _movement.canceled += OnMovement;
        _look.performed += OnLook;
        _interact.performed += OnInteract;
        _mask.performed += OnMask;
        _escape.performed += OnEscape;
        _enterCode.performed += OnEnterCode;
    }

    private void OnDisable()
    {
        _movement.performed -= OnMovement;
        _movement.canceled -= OnMovement;
        _look.performed -= OnLook;
        _interact.performed += OnInteract;
        _mask.performed += OnMask;
        _escape.performed += OnEscape;
        _enterCode.performed += OnEnterCode;

        _inputActions.PlayerAction.Disable();
    }

    private void OnMovement(InputAction.CallbackContext context)
    {
        Main.Movement.OnMovement(context.ReadValue<Vector3>());
    }

    /// <summary>
    /// Input function to move the player camera vision
    /// </summary>
    /// <param name="context"></param>
    private void OnLook(InputAction.CallbackContext context)
    {
        Main.Movement.OnLook(context.ReadValue<Vector2>());
    }

    /// <summary>
    /// Input function to interact
    /// </summary>
    /// <param name="context"></param>
    private void OnInteract(InputAction.CallbackContext context)
    {
        Main.Interact.Interact();
    }

    /// <summary>
    /// Input function to change mask
    /// </summary>
    /// <param name="context"></param>
    private void OnMask(InputAction.CallbackContext context)
    {
        Main.Mask.ChangeMask();
    }

    /// <summary>
    /// Input function to pause the game or close zoom in UI
    /// </summary>
    /// <param name="context"></param>
    private void OnEscape(InputAction.CallbackContext context)
    {
        //Option ou désactive le zoom in
        if (Main.PlayerDesactivateByUIZoomIn)
        {
            GameManager.Instance.UI.ZoomIn.CloseZoomIn();
            Main.ActivatePlayer();
        }
        else
        {
            //Open menu option
        }
    }

    /// <summary>
    /// Input function to enter code in code lock UI
    /// </summary>
    /// <param name="context"></param>
    private void OnEnterCode(InputAction.CallbackContext context)
    {
        if (Main.PlayerDesactivateByUIZoomIn)
        {
            GameManager.Instance.UI.CodeLock.EnterCode();
        }
    }
}