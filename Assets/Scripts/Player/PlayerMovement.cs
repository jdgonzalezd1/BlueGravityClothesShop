using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    
    private CustomInput customInput;

    private Vector2 moveVector; 

    private Rigidbody2D rb;
    
    private void Awake()
    {
        customInput = new CustomInput();
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnEnable()
    {
        customInput.Enable();
        customInput.Player.Movement.performed += OnMovementPerformed;
        customInput.Player.Movement.canceled += OnMovementCancelled;
    }

    private void OnDisable()
    {
        customInput.Disable();
        customInput.Player.Movement.performed -= OnMovementPerformed;
        customInput.Player.Movement.canceled -= OnMovementCancelled;
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;
    }

    private void OnMovementPerformed(InputAction.CallbackContext argValue)
    {
        moveVector = argValue.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext argValue)
    {
        moveVector = Vector2.zero;
    }
}
