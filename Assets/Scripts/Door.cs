using UnityEngine;
using System;
using System.Collections.Generic;

public class Door : MonoBehaviour
{
    public GameObject LinkedPlayer;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag != LinkedPlayer.tag)
            return;

        GetCollider2D().enabled = false;
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag != LinkedPlayer.tag)
            return;

        GetCollider2D().enabled = true;    
    }

    private Collider2D GetCollider2D()
    {
        Collider2D[] colliders = gameObject.GetComponents<Collider2D>();

        for (int i = 0; i < colliders.Length; i++)
        {
            if (!colliders[i].isTrigger)
            {
                return colliders[i];
            }
        }

        return null;
    }
}
