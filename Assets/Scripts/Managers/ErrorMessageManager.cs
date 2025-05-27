using TMPro;
using UnityEngine;

public class ErrorMessageManager : MonoBehaviour
{
    public GameObject errorText;
    public static ErrorMessageManager Instance { get; private set; }

    private void Awake()
    {
        // 싱글톤 인스턴스 설정
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("ErrorMessageManager의 중복 인스턴스가 감지되었습니다. 기존 인스턴스를 유지합니다.");
            Destroy(gameObject); // 중복된 인스턴스 제거
            return;
        }

    }

    public void ShowErrorMessage(string errorMessage)
    {
        GameObject newErrorText = Instantiate(errorText, transform);
        newErrorText.GetComponent<TextMeshProUGUI>().text = errorMessage;
    }
}
