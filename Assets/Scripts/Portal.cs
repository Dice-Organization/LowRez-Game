using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject form;
    public Transform portal;
    public float offsetx, offsety;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag==form.tag)
        {
            SoundEffects.Instance.Audio.PlayOneShot(SoundEffects.Instance._teleportClip);
            form.transform.position = new Vector2(portal.position.x + offsetx, portal.position.y + offsety);
        }
        
    }
}
