using UnityEngine;
using UnityEngine.SceneManagement;
public class EndLevel : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Blended")
        {
            GameManager.Instance.LoadScene();
            
        }
    }
}
