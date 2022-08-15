using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blend : MonoBehaviour
{
    public GameObject BlendedPrefab;
    public List<GameObject> BlendedObjects;

    public void BlendObjects()
    {
        // SoundEffects.Instance.Audio.PlayOneShot(SoundEffects.Instance._blendClip);
        Instantiate(BlendedPrefab,BlendedObjects[0].transform.position,BlendedObjects[0].transform.rotation);
        for (int i = 0; i < BlendedObjects.Count; i++)
        {
            BlendedObjects[i].SetActive(!BlendedObjects[i].activeSelf);
        }
    }
}
