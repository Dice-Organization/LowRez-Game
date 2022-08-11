
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Collections;
using System;

public class Button : MonoBehaviour
{
    public List<GameObject> LinkedDoors;
    public  GameObject LinkedPlayerForm;
    public CinemachineTargetGroup TargetGroup;

    private bool _isPressed;
    private bool _canInteract;
    private Interact _playerInteract;
    private Animator _animator;

    private CinemachineBrain _brain;
    private CinemachineVirtualCamera _activeCamera;

    private void Awake() 
    {
        _brain = Camera.main.GetComponent<CinemachineBrain>();
        _playerInteract = LinkedPlayerForm.GetComponent<Interact>();
        _animator = GetComponent<Animator>();
        

        _playerInteract.PlayerInteract += OpenDoor;
    }

  

    public void OpenDoor()
    {
        if(_isPressed || !_canInteract)
            return;

         foreach (GameObject linkedDoor in LinkedDoors)
        {            
            _activeCamera.Follow = linkedDoor.transform;
            linkedDoor.SetActive(false);
        }


        _isPressed = true;
        _canInteract = false;

        
        _animator.SetTrigger("IsPressed");
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == LinkedPlayerForm.tag)
        {
            _canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
       if(other.tag == LinkedPlayerForm.tag)
        {
            _canInteract = false;
            ReturnCamera();
        } 
    }
    private void Update() 
    {
        _animator.SetBool("IsInRange",_canInteract);
        _activeCamera = (CinemachineVirtualCamera)_brain.ActiveVirtualCamera;

        
    }

    private void ReturnCamera()
    {
        _activeCamera.Follow = LinkedPlayerForm.transform;
    }
}
