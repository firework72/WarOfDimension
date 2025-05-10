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

    public Tower selectedTower; // ���õ� Ÿ��
    public GameObject gachaTower; // �̱�� ȹ���� Ÿ��

    public Button gachaButton; // �̱� ��ư
    public Button upgradeButton; // ���׷��̵� ��ư
    public Button removeButton; // ���� ��ư

    public GameObject towerUpgradeUI; // Ÿ�� ���� �г�

    public GameObject towerImage;
    public GameObject towerLvlText;

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

        towerImage.GetComponent<Image>().sprite = tower.GetComponent<SpriteRenderer>().sprite;
        towerLvlText.GetComponent<TextMeshProUGUI>().text = "Lv." + tower.towerLvl.ToString();

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
            Destroy(selectedTower.gameObject);
            selectedTower = null;
            towerUpgradeUI.SetActive(false);
        }
    }
}