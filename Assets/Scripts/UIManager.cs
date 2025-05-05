using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject goldText;
    public GameObject expText;
    public GameObject nexusHpText;
    public GameObject curStageText;
    public GameObject remainTimeText;

    public Tower selectedTower; // 선택된 타워
    public GameObject gachaTower; // 뽑기로 획득한 타워

    public Button gachaButton; // 뽑기 버튼
    public Button upgradeButton; // 업그레이드 버튼
    public Button removeButton; // 제거 버튼

    public GameObject towerUpgradeUI; // 타워 정보 패널

    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(UIManager)) as UIManager;
            }

            return _instance;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        goldText.GetComponent<TextMeshProUGUI>().text = "Gold : " + GameManager.Instance.gold.ToString();
        expText.GetComponent<TextMeshProUGUI>().text = "Exp : " + GameManager.Instance.exp.ToString();
        nexusHpText.GetComponent<TextMeshProUGUI>().text = "NexusHp : " + GameManager.Instance.nexusHp.ToString();
        curStageText.GetComponent<TextMeshProUGUI>().text = "Wave " + (GameManager.Instance.curStage + 1).ToString();
        remainTimeText.GetComponent<TextMeshProUGUI>().text = GameManager.Instance.remainTime.ToString("F1") + "s";
    }

    public void ShowTowerUpgradeUI(Tower tower)
    {
        selectedTower = tower;

        towerUpgradeUI.SetActive(true);
    }

    public void OnUpgradeButtonClicked()
    {
        if (selectedTower != null)
        {
            selectedTower.Upgrade();
            selectedTower = null;
            towerUpgradeUI.SetActive(false);
        }
    }

    public void OnRemoveButtonClicked()
    {
        if (selectedTower != null)
        {
            Destroy(selectedTower);
            selectedTower = null;
            towerUpgradeUI.SetActive(false);
        }
    }
}