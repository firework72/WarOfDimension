using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject goldText;
    public GameObject lvlText;
    public GameObject nexusHpText;
    public GameObject curStageText;
    public GameObject remainTimeText;

    public Tower selectedTower; // ���õ� Ÿ��
    public GameObject gachaTower; // �̱�� ȹ���� Ÿ��

    public Button gachaButton; // �̱� ��ư

    public GameObject gemImage;
    public GameObject upgradeCostText;
    public Button upgradeButton; // ���׷��̵� ��ư
    public Button removeButton; // ���� ��ư

    public GameObject towerUpgradeUI; // Ÿ�� ���� �г�

    public GameObject towerImage;
    public GameObject towerLvlText;

    public GameObject expProgressBar;

    public GameObject fireRateInfoText;
    public GameObject fireRateUpgradeCostText;
    public GameObject damageInfoText;
    public GameObject damageUpgradeCostText;
    public GameObject expInfoText;
    public GameObject expUpgradeCostText;
    public GameObject goldInfoText;
    public GameObject goldUpgradeCostText;

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
        goldText.GetComponent<TextMeshProUGUI>().text = GameManager.Instance.gold.ToString();
        lvlText.GetComponent<TextMeshProUGUI>().text = "Lv." + GameManager.Instance.lvl.ToString();
        nexusHpText.GetComponent<TextMeshProUGUI>().text = GameManager.Instance.nexusHp.ToString();
        curStageText.GetComponent<TextMeshProUGUI>().text = "Wave " + (GameManager.Instance.curStage + 1).ToString();
        remainTimeText.GetComponent<TextMeshProUGUI>().text = GameManager.Instance.remainTime.ToString("F1") + "s";

        fireRateInfoText.GetComponent<TextMeshProUGUI>().text = "x" + (GameManager.Instance.fireRateBonus).ToString("F2");
        fireRateUpgradeCostText.GetComponent<TextMeshProUGUI>().text =( GameManager.Instance.fireRateBonusLvl * 100).ToString();
        damageInfoText.GetComponent<TextMeshProUGUI>().text = "x" + (GameManager.Instance.damageBonus).ToString("F2");
        damageUpgradeCostText.GetComponent<TextMeshProUGUI>().text = (GameManager.Instance.damageBonusLvl * 100).ToString();
        expInfoText.GetComponent<TextMeshProUGUI>().text = "x" + (GameManager.Instance.expBonus).ToString("F2");
        expUpgradeCostText.GetComponent<TextMeshProUGUI>().text = (GameManager.Instance.expBonusLvl * 100).ToString();
        goldInfoText.GetComponent<TextMeshProUGUI>().text = "x" + (GameManager.Instance.goldBonus).ToString("F2");
        goldUpgradeCostText.GetComponent<TextMeshProUGUI>().text = (GameManager.Instance.goldBonusLvl * 100).ToString();

        // 업그레이드 버튼 텍스트 변경


        UpdateExpProgressBar();
    }

    public void ShowTowerUpgradeUI(Tower tower)
    {
        selectedTower = tower;

        if (tower is StarTower)
        {
            gemImage.SetActive(false);
            upgradeCostText.SetActive(false);
            upgradeButton.interactable = false;
        }
        else
        {
            gemImage.SetActive(true);
            upgradeCostText.SetActive(true);
            upgradeButton.interactable = true;
        }

        towerImage.GetComponent<Image>().sprite = tower.GetComponent<SpriteRenderer>().sprite;
        towerLvlText.GetComponent<TextMeshProUGUI>().text = "Lv." + tower.towerLvl.ToString();
        towerUpgradeUI.transform.Find("UpgradeCostText").GetComponent<TextMeshProUGUI>().text = tower.upgradeCost.ToString();

        Debug.Log("Selected Tower: " + tower.gameObject.name);
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

    public void UpdateExpProgressBar()
    {
        expProgressBar.GetComponent<Slider>().minValue = 0;
        expProgressBar.GetComponent<Slider>().maxValue = GameManager.Instance.lvl * 100;
        expProgressBar.GetComponent<Slider>().value = GameManager.Instance.exp;
    }
}