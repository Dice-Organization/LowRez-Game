
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public List<GameObject> LinkedDoors;
    public  GameObject LinkedPlayerForm;

    private bool _isPressed;
    private bool _canInteract;
    private Interact _playerInteract;
    private Animator _animator;

    private void Awake() 
    {
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
        } 
    }
    private void Update() 
    {
        _animator.SetBool("IsInRange",_canInteract);
    }
}
