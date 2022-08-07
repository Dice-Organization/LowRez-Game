
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject LinkedDoor;
    public  GameObject LinkedPlayerForm;

    private bool _isPressed;
    private bool _canInteract;
    private Interact _playerInteract;

    private void Awake() 
    {
        _playerInteract = LinkedPlayerForm.GetComponent<Interact>();
        

        _playerInteract.PlayerInteract += OpenDoor;
    }

    public void OpenDoor()
    {
        
        if(_isPressed || !_canInteract)
            return;

      
        LinkedDoor.SetActive(false);

        _isPressed = true;
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
}
