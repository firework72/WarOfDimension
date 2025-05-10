using UnityEngine;

public class ErrorText : MonoBehaviour
{
   void Awake()
    {
        Debug.Log("new ErrorText created");
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.y = pos.y + Time.deltaTime * 200;
        transform.position = pos;

        if (transform.position.y >= 200)
        {
            Destroy(gameObject);
        }
    }
}
