using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using System;

public class FormControll : MonoBehaviour
{
    private PlayerActions _playerInput;

    [SerializeField]
    private GameObject _form1;
    [SerializeField]
    private GameObject _form2;
    private CinemachineVirtualCamera _virtualCamera1;
    private CinemachineVirtualCamera _virtualCamera2;
    private bool _canSwap;
    private bool _canSwitch;

    private void Awake() 
    {
        _playerInput = new();

        _playerInput.PlayerInput.Switch.started += OnSwitch;
        _playerInput.PlayerInput.Switch.canceled += OnSwitch;
        _playerInput.PlayerInput.Swap.started += OnSwap;
        _playerInput.PlayerInput.Swap.canceled += OnSwap;
         
        _virtualCamera1 = _form1.GetComponentInChildren<CinemachineVirtualCamera>(); 
        _virtualCamera2 = _form2.GetComponentInChildren<CinemachineVirtualCamera>();

    }

    private void OnSwap(InputAction.CallbackContext context)
    {
        _canSwap = context.ReadValueAsButton();

    }

    private void OnSwitch(InputAction.CallbackContext context)
    {
        _canSwitch = context.ReadValueAsButton();
    }

    private void Update() 
    {
        
        if(_canSwitch)
            Switch();
        if(_canSwap)
            Swap();
        
    }

    private void Swap()
    {
        SoundEffects.Instance.Audio.PlayOneShot(SoundEffects.Instance._swapClip);
        Vector2 form1Position = _form1.transform.position;
        Vector2 form2Position = _form2.transform.position; 
        
        _form1.transform.position = form2Position;
        _form2.transform.position = form1Position;

        _canSwap = false;
    }

    private void Switch()
    {
        DisableForms();
        _canSwitch = false;
    }

    private void DisableForms()
    {
        SoundEffects.Instance.Audio.PlayOneShot(SoundEffects.Instance._switchClip);
        _form1.GetComponent<Movement_Controll>().enabled = !_form1.GetComponent<Movement_Controll>().enabled;
        _form2.GetComponent<Movement_Controll>().enabled = !_form2.GetComponent<Movement_Controll>().enabled;
        _form1.GetComponent<Interact>().enabled = !_form1.GetComponent<Interact>().enabled;
        _form2.GetComponent<Interact>().enabled = !_form2.GetComponent<Interact>().enabled;
        _virtualCamera1.enabled = !_virtualCamera1.enabled;
        _virtualCamera2.enabled = !_virtualCamera2.enabled;
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
