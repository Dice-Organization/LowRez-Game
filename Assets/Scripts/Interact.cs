using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    public event Action PlayerInteract;
    private PlayerActions _playerInput;

   

    private void Awake() 
    {
        _playerInput = new();    

        _playerInput.PlayerInput.Interact.started += OnInteract;
        _playerInput.PlayerInput.Interact.canceled += OnInteract;
    }

    private void OnInteract(InputAction.CallbackContext obj)
    {
        PlayerInteract?.Invoke();
    }

    private void OnEnable() 
    {
        _playerInput.PlayerInput.Enable();
    }

    private void OnDisable() 
    {
        _playerInput.PlayerInput.Disable();    
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
