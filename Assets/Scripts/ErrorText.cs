using UnityEngine;

public class ErrorText : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("new ErrorText created");

        // RectTransform ��������
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

        // �θ� Canvas���� Ȯ��
        if (rectTransform == null || rectTransform.parent == null)
        {
            Debug.LogError("ErrorText�� Canvas ������ �־�� �մϴ�.");
            return;
        }

        // ��Ŀ�� Canvas�� �߾����� ����
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);

        // �߾ӿ� ��ġ�ϵ��� ����
        rectTransform.anchoredPosition = Vector2.zero;
    }

    void Update()
    {
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

        // ���� �̵�
        Vector3 pos = rectTransform.anchoredPosition;
        pos.y += Time.deltaTime * 150; // �ӵ� ����
        rectTransform.anchoredPosition = pos;

        // Ư�� ���̿� �����ϸ� ����
        if (rectTransform.anchoredPosition.y >= 150)
        {
            Destroy(gameObject);
        }
    }
}