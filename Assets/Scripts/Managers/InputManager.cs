using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public Button fireRateUpgradeButton;
    public Button damageUpgradeButton;
    public Button expUpgradeButton;
    public Button goldUpgradeButton;
    public Button towerUpgradeButton;
    public Button towerRemoveButton;

    void Update()
    {
        // 키보드 입력받아 버튼 기능능 실행
        if (Input.GetKeyDown(KeyCode.R))
        {
            fireRateUpgradeButton.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            damageUpgradeButton.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            expUpgradeButton.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            goldUpgradeButton.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            towerUpgradeButton.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            towerRemoveButton.onClick.Invoke();
        }
    }
}