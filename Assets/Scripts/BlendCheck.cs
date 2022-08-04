using UnityEngine;
using UnityEngine.Events;

public class BlendCheck : MonoBehaviour
{
    public UnityEvent OnBlend;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Form 1" || other.gameObject.tag == "Form 2")
        {
            OnBlend.Invoke();
        }
    }
}
