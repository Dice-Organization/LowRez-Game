using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class Movement_Controll : MonoBehaviour
{
   
    private const int _speed = 4;
    private PlayerActions _playerInput;
    private Vector2 _playerMovement;
    private Vector2 _playerMovementInput;


    private void Awake()
    {
        _playerInput = new();

        _playerInput.PlayerInput.Movement.started += OnMove;
        _playerInput.PlayerInput.Movement.performed += OnMove;
        _playerInput.PlayerInput.Movement.canceled += OnMove;
    }

    private void FixedUpdate() 
    {
        transform.position = (Vector2)transform.position + (_playerMovement * _speed * Time.deltaTime);    
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _playerMovementInput = context.ReadValue<Vector2>();
        _playerMovement = _playerMovementInput;
    }

    private void OnEnable()
    {
        _playerInput.PlayerInput.Enable();    
    }

    private void OnDisable() 
    {
        _playerInput.PlayerInput.Disable();    
    }

}
