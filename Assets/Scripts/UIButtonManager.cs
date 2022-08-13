using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonManager : MonoBehaviour
{
    public void LoadScene()
    {
        GameManager.Instance.LoadScene();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
