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

    public GameObject towerCreateGoldText;

    private static UIManager _instance;

    // 보스 HP UI 관련 변수
    [Header("Boss UI")]
    public GameObject bossHpUI; // 보스 HP UI 전체를 담는 GameObject
    public Slider bossHpSlider; // 보스 HP를 표시할 Slider
    public TextMeshProUGUI bossHpText;  // 보스 HP를 텍스트로 표시할 Text

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
        // 초기 상태에서는 보스 HP UI를 숨김
        if (bossHpUI != null)
        {
            bossHpUI.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        goldText.GetComponent<TextMeshProUGUI>().text = GameManager.Instance.gold.ToString();
        lvlText.GetComponent<TextMeshProUGUI>().text = "Lv." + GameManager.Instance.lvl.ToString();
        nexusHpText.GetComponent<TextMeshProUGUI>().text = "HP : " + GameManager.Instance.nexusHp.ToString();
        curStageText.GetComponent<TextMeshProUGUI>().text = "Wave " + (GameManager.Instance.curStage + 1).ToString();
        remainTimeText.GetComponent<TextMeshProUGUI>().text = GameManager.Instance.remainTime.ToString("F1") + "s";

        fireRateInfoText.GetComponent<TextMeshProUGUI>().text = "x" + (GameManager.Instance.fireRateBonus).ToString("F2");
        fireRateUpgradeCostText.GetComponent<TextMeshProUGUI>().text = (GameManager.Instance.fireRateBonusLvl * 100).ToString();
        damageInfoText.GetComponent<TextMeshProUGUI>().text = "x" + (GameManager.Instance.damageBonus).ToString("F2");
        damageUpgradeCostText.GetComponent<TextMeshProUGUI>().text = (GameManager.Instance.damageBonusLvl * 100).ToString();
        expInfoText.GetComponent<TextMeshProUGUI>().text = "x" + (GameManager.Instance.expBonus).ToString("F2");
        expUpgradeCostText.GetComponent<TextMeshProUGUI>().text = (GameManager.Instance.expBonusLvl * 100).ToString();
        goldInfoText.GetComponent<TextMeshProUGUI>().text = "x" + (GameManager.Instance.goldBonus).ToString("F2");
        goldUpgradeCostText.GetComponent<TextMeshProUGUI>().text = (GameManager.Instance.goldBonusLvl * 100).ToString();
        towerCreateGoldText.GetComponent<TextMeshProUGUI>().text = "Tower Create: " + (GameManager.Instance.towerInstallCost).ToString();
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
            bool upgradeSuccess = selectedTower.Upgrade();
            if (upgradeSuccess)
            {
                selectedTower = null;
                towerUpgradeUI.SetActive(false);
            }
            // 실패 시에는 창을 닫지 않음
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

    // 보스 HP UI를 업데이트하는 함수
    public void UpdateBossHpUI(int currentHp, int maxHp)
    {
        if (bossHpUI == null || bossHpSlider == null)
        {
            Debug.LogError("Boss HP UI 또는 Slider가 UIManager에 할당되지 않았습니다.");
            return;
        }

        // 보스 HP UI를 활성화
        bossHpUI.SetActive(true);

        bossHpSlider.maxValue = maxHp;
        bossHpSlider.value = currentHp;

        if (bossHpText != null)
        {
            bossHpText.text = $"{currentHp} / {maxHp}";
        }
    }

    // 보스 HP UI를 숨기는 함수(보스 사망 시 호출)
    public void HideBossHpUI()
    {
        if (bossHpUI != null)
        {
            bossHpUI.SetActive(false);

        }
    }
}