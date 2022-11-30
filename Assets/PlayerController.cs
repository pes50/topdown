using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    private PlayerInputActions playerControls;
    private InputAction move;
    private InputAction look;
    private InputAction fire;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        look = playerControls.Player.Look;
        look.Enable();

        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }

    private void OnDisable()
    {
        move.Disable();
        look.Disable();
        fire.Disable();
    }

    void Start()
    {
        
    }

    void Update()
    {
        HandleMovementInput();
        HandleRotationInput();
    }

    void HandleMovementInput() {
        Vector2 movementInput = move.ReadValue<Vector2>();
        Vector3 movement = new Vector3(movementInput.x, 0, movementInput.y);
        transform.position += movement * movementSpeed * Time.deltaTime;
    }

    void HandleRotationInput() {
        Vector2 lookInput = look.ReadValue<Vector2>();
        if (lookInput.magnitude > 0.1f)
        {
            Vector3 lookDirection = new Vector3(lookInput.x, 0, lookInput.y);
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
    }

    private void Fire(InputAction.CallbackContext context) {
        Debug.Log("FIRE!");
    }
}
