using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerMain Main;
    internal Rigidbody rb;

    [Header("Camera")]
    public Transform VerticalHead;
    private Transform _horizontalPlayer;
    [SerializeField] internal float mouseSensitivity = 2f;

    [Header("Movement")]
    [SerializeField] internal float _moveSpeed = 5f;
    [SerializeField] private float _walkingAmplitude;
    [SerializeField] private float _walkingFrequency;

    internal float moveHorizontal;
    internal float moveForward;

    private bool _isMoving;

    public void Init(PlayerMain main)
    {
        Main = main;
        _horizontalPlayer = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();

        // Hides the mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (!Main.PlayerDesactivate)
        {
            Vector3 movement = (transform.right * moveHorizontal + transform.forward * moveForward).normalized;
            float speed = _moveSpeed;
            Vector3 targetVelocity = movement * speed;
            // Apply movement to the Rigidbody
            Vector3 velocity = rb.linearVelocity;
            velocity.x = targetVelocity.x;
            velocity.z = targetVelocity.z;

            rb.linearVelocity = velocity;

            // If we aren't moving and are on the ground, stop velocity so we don't slide
            if (moveHorizontal == 0 && moveForward == 0)
            {
                rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
                GameManager.Instance.Cam.HeadBobbingStop();
                if (_isMoving)
                {
                    _isMoving = false;
                    Main.Sound.StopFootstep();
                }
            }
            else
            {
                GameManager.Instance.Cam.HeadBobbingWalking();
                if (!_isMoving)
                {
                    _isMoving = true;
                    Main.Sound.PlayFootstep();
                }
            }
        }
    }

    #region Camera
    /// <summary>
    /// Rotate the camera
    /// </summary>

    public void OnLook(Vector2 look)
    {
        if (!Main.PlayerDesactivate)
        {
            Vector2 lookValue = look;

            float horizontalRotation = lookValue.x * mouseSensitivity;
            _horizontalPlayer.Rotate(0, horizontalRotation, 0);

            float verticalRotation = -lookValue.y * mouseSensitivity;
            Mathf.Clamp(VerticalHead.rotation.y, -90f, 90f);
            VerticalHead.Rotate(verticalRotation, 0, 0);
            VerticalHead.eulerAngles = new Vector3(Mathf.Clamp(-Mathf.DeltaAngle(VerticalHead.eulerAngles.x, 0), -90, 90), transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
    #endregion

    /// <summary>
    /// Use the input system to change our movement
    /// </summary>
    /// <param name="movement"></param>
    internal virtual void OnMovement(Vector3 movement)
    {
        moveHorizontal = movement.x;
        moveForward = movement.z;
    }

    public void StopPlayer()
    {
        rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
        GameManager.Instance.Cam.HeadBobbingStop();
        Main.Sound.StopFootstep();
        _isMoving = false;
    }
}
