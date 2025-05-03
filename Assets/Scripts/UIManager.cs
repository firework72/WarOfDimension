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

    public GameObject selectedTower; // ���õ� Ÿ��
    public GameObject gachaTower; // �̱�� ȹ���� Ÿ��

    public Button gachaButton; // �̱� ��ư
    public Button upgradeButton; // ���׷��̵� ��ư
    public Button removeButton; // ���� ��ư

    public GameObject towerUpgradeUI; // Ÿ�� ���� �г�

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
        curStageText.GetComponent<TextMeshProUGUI>().text = "Wave " + GameManager.Instance.curStage.ToString();
        remainTimeText.GetComponent<TextMeshProUGUI>().text = GameManager.Instance.remainTime.ToString("F1") + "s";
    }

    public void ShowTowerUpgradeUI(GameObject tower)
    {
        selectedTower = tower;

        towerUpgradeUI.SetActive(true);
    }

    public void OnUpgradeButtonClicked()
    {

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