using UnityEngine;

public class ErrorText : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("new ErrorText created");

        // RectTransform 가져오기
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

        // 부모가 Canvas인지 확인
        if (rectTransform == null || rectTransform.parent == null)
        {
            Debug.LogError("ErrorText는 Canvas 하위에 있어야 합니다.");
            return;
        }

        // 앵커를 Canvas의 중앙으로 설정
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);

        // 중앙에 위치하도록 설정
        rectTransform.anchoredPosition = Vector2.zero;
    }

    void Update()
    {
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

        // 위로 이동
        Vector3 pos = rectTransform.anchoredPosition;
        pos.y += Time.deltaTime * 150; // 속도 조정
        rectTransform.anchoredPosition = pos;

        // 특정 높이에 도달하면 제거
        if (rectTransform.anchoredPosition.y >= 150)
        {
            Destroy(gameObject);
        }
    }
}