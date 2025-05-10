using UnityEngine;

public class ClickManager : MonoBehaviour
{
    void Update()
{
    if (Input.GetMouseButtonDown(1)) // 마우스 오른쪽 버튼 클릭
    {
        Debug.Log("Right mouse button clicked.");
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스 위치를 월드 좌표로 변환
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero); // 해당 위치에서 레이캐스트 실행

        if (hit.collider != null) // 충돌한 오브젝트가 있는지 확인
        {
            if (hit.collider.CompareTag("Path") || hit.collider.CompareTag("Tower")) // 특정 태그 확인
            {
                Debug.Log("You cannot install tower here.");
                return; // 설치를 막기 위해 함수 종료
            }
        }

        // 충돌한 오브젝트가 없거나 설치 가능한 위치일 경우 타워 설치
        GameManager.Instance.InstallTower();
    } 
}
}
