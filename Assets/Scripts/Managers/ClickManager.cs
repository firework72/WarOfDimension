using UnityEngine;

public class ClickManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // 마우스 오른쪽 버튼 클릭
        {
            
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스 위치를 월드 좌표로 변환
            Debug.Log("Right mouse button clicked. X: " + mousePosition.x + ", Y: " + mousePosition.y);
            if (mousePosition.x < -4.5f || mousePosition.x > 4.3f || mousePosition.y < -2.8f || mousePosition.y > 3.1f)
            {
                Debug.Log("You cannot install tower here.");
                // 설치 불가능한 영역에 타워를 설치하려고 할 때 에러 메시지 표시
                ErrorMessageManager.Instance.ShowErrorMessage("You cannot install tower here"); // 에러 메시지 표시
                return; // 설치를 막기 위해 함수 종료
            }
            // 반경 1 내에 타워가 있는지 확인
            Collider2D[] nearbyTowers = Physics2D.OverlapCircleAll(mousePosition, 0.5f);
            foreach (var collider in nearbyTowers)
            {
                if (collider.CompareTag("Tower"))
                {
                    Debug.Log("A tower is too close to this position.");
                    ErrorMessageManager.Instance.ShowErrorMessage("A tower is too close to this position."); // 에러 메시지 표시
                    return; // 설치를 막기 위해 함수 종료
                }
            }

            // 반경 0.65 이내에 Path가 있는지 확인
            Collider2D[] nearbyPaths = Physics2D.OverlapCircleAll(mousePosition, 0.35f);
            foreach (var collider in nearbyPaths)
            {
                if (collider.CompareTag("Path"))
                {
                    Debug.Log("A path is too close to this position.");
                    ErrorMessageManager.Instance.ShowErrorMessage("A path is too close to this position."); // 에러 메시지 표시
                    return; // 설치를 막기 위해 함수 종료
                }
            }

            // 충돌한 오브젝트가 없거나 설치 가능한 위치일 경우 타워 설치
            GameManager.Instance.InstallTower();
        }
    }
}
