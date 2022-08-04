using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blend : MonoBehaviour
{
    public GameObject BlendedPrefab;
    public List<GameObject> BlendedObjects;

    public void BlendObjects()
    {
        Instantiate(BlendedPrefab,BlendedObjects[0].transform.position,BlendedObjects[0].transform.rotation);
        for (int i = 0; i < BlendedObjects.Count; i++)
        {
            BlendedObjects[i].SetActive(!BlendedObjects[i].activeSelf);
        }
    }
}
