using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    
    private CustomInput input;

    private Vector2 moveVector; 

    private Rigidbody2D rb;
    
    private void Awake()
    {
        input = new CustomInput();
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCancelled;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCancelled;
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
