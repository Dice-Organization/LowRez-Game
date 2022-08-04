using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using System;

public class Switch : MonoBehaviour
{
    private PlayerActions _playerInput;

    private GameObject _form1;
    private GameObject _form2;
    private CinemachineVirtualCamera _virtualCamera1;
    private CinemachineVirtualCamera _virtualCamera2;
    private bool _canSwap;

    private void Awake() 
    {
        _playerInput = new();

        _playerInput.PlayerInput.Swap.started += OnSwap;
        _playerInput.PlayerInput.Swap.canceled += OnSwap;
         
        _form1 = GameObject.FindGameObjectWithTag("Form 1");
        _form2 = GameObject.FindGameObjectWithTag("Form 2");    
        _virtualCamera1 = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        _virtualCamera2 = GameObject.Find("CM vcam2").GetComponent<CinemachineVirtualCamera>();

    }

    private void OnSwap(InputAction.CallbackContext context)
    {
        _canSwap = context.ReadValueAsButton();
    }

    private void Update() 
    {
        if(_canSwap)
        {
            Swap();
        }
    }

    private void Swap()
    {
        _form1.GetComponent<Movement_Controll>().enabled = !_form1.GetComponent<Movement_Controll>().enabled;
        _form2.GetComponent<Movement_Controll>().enabled = !_form2.GetComponent<Movement_Controll>().enabled;
        _virtualCamera1.enabled = !_virtualCamera1.enabled;
        _virtualCamera2.enabled = !_virtualCamera2.enabled;
        _canSwap = false;
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
