using UnityEngine;

public class HitEffect : MonoBehaviour
{
    void Awake()
    {
        Invoke("DestroyEffect", 1.0f);
    }

    void DestroyEffect()
    {
        Destroy(gameObject);
    }
}
