using TMPro;
using UnityEngine;

public class ErrorMessageManager : MonoBehaviour
{
    public GameObject errorText;
    public static ErrorMessageManager Instance { get; private set; }

    private void Awake()
    {
        // �̱��� �ν��Ͻ� ����
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("ErrorMessageManager�� �ߺ� �ν��Ͻ��� �����Ǿ����ϴ�. ���� �ν��Ͻ��� �����մϴ�.");
            Destroy(gameObject); // �ߺ��� �ν��Ͻ� ����
            return;
        }

    }

    public void ShowErrorMessage(string errorMessage)
    {
        GameObject newErrorText = Instantiate(errorText, transform);
        newErrorText.GetComponent<TextMeshProUGUI>().text = errorMessage;
    }
}
