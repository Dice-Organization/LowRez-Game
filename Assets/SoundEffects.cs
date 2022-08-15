using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public static SoundEffects Instance;
    public AudioSource Audio;
    public AudioClip _switchClip;
    public AudioClip _swapClip;
    public AudioClip _teleportClip;
    public AudioClip _blendClip;
    public AudioClip _doorOpenClip;
    public AudioClip MenuClip;
    private void Awake() 
    {
        if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }    
    }
}
