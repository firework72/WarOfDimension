using UnityEngine;

public class HitEffect : MonoBehaviour
{
    void Awake()
    {
        Invoke("DestroyEffect", 1.5f);
    }

    void DestroyEffect()
    {
        Destroy(gameObject);
    }
}
