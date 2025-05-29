using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;
            }

            return _instance;
        }
    }

    public GameObject[] enemy; // 적 프리팹들

    // 웨이브에 따라 스폰되는 적의 수 (0~5번째 값은 적의 종류, 6번째 값은 보스 여부)
    // public static int[][] spawnData = new int[30][]
    // {
    //    new int[] {5, 0, 0, 0, 0, 0, 0}, // 웨이브 1  
    //    new int[] {5, 5, 0, 0, 0, 0, 0}, // 웨이브 2  
    //    new int[] {5, 5, 5, 0, 0, 0, 0}, // 웨이브 3  
    //    new int[] {5, 5, 5, 5, 0, 0, 0}, // 웨이브 4  
    //    new int[] {5, 5, 5, 5, 5, 0, 0}, // 웨이브 5  
    //    new int[] {5, 5, 5, 5, 5, 5, 0}, // 웨이브 6  
    //    new int[] {10, 5, 5, 5, 5, 5, 0}, // 웨이브 7  
    //    new int[] {10, 10, 5, 5, 5, 5, 0}, // 웨이브 8  
    //    new int[] {10, 10, 10, 5, 5, 5, 0}, // 웨이브 9  
    //    new int[] {10, 10, 10, 10, 5, 5, 0}, // 웨이브 10  
    //    new int[] {10, 10, 10, 10, 10, 5, 0}, // 웨이브 11  
    //    new int[] {10, 10, 10, 10, 10, 10, 0}, // 웨이브 12  
    //    new int[] {15, 10, 10, 10, 10, 10, 0}, // 웨이브 13  
    //    new int[] {15, 15, 10, 10, 10, 10, 0}, // 웨이브 14  
    //    new int[] {15, 15, 15, 10, 10, 10, 0}, // 웨이브 15  
    //    new int[] {15, 15, 15, 15, 10, 10, 0}, // 웨이브 16  
    //    new int[] {15, 15, 15, 15, 15, 10, 0}, // 웨이브 17  
    //    new int[] {15, 15, 15, 15, 15, 15, 0}, // 웨이브 18  
    //    new int[] {20, 15, 15, 15, 15, 15, 0}, // 웨이브 19  
    //    new int[] {20, 20, 15, 15, 15, 15, 0}, // 웨이브 20  
    //    new int[] {20, 20, 20, 15, 15, 15, 0}, // 웨이브 21  
    //    new int[] {20, 20, 20, 20, 15, 15, 0}, // 웨이브 22  
    //    new int[] {20, 20, 20, 20, 20, 15, 0}, // 웨이브 23  
    //    new int[] {20, 20, 20, 20, 20, 20, 0}, // 웨이브 24  
    //    new int[] {25, 20, 20, 20, 20, 20, 0}, // 웨이브 25  
    //    new int[] {25, 25, 20, 20, 20, 20, 0}, // 웨이브 26  
    //    new int[] {25, 25, 25, 20, 20, 20, 0}, // 웨이브 27  
    //    new int[] {25, 25, 25, 25, 20, 20, 0}, // 웨이브 28  
    //    new int[] {25, 25, 25, 25, 25, 20, 0}, // 웨이브 29
    //    new int[] {0, 0, 0, 0, 0, 0, 1}  // 웨이브 30  
    // };
    
    public static int[] spawnData = new int[7] {0, 0, 0, 0, 0, 0, 0};

    private int[] spawnedCnt = new int[7] { 0, 0, 0, 0, 0, 0, 0 }; // 각 웨이브에서 스폰된 적의 수 (0~5번째 값은 적의 종류, 6번째 값은 보스 여부)

    private int curTargetEnemy = 0;
    private int curTargetEnemySpawnCnt = 0;
    public int gold = 500; // 현재 골드
    public int exp = 0; // 현재 경험치

    public int curStage = -1; // 현재 진행 중인 스테이지
    public float remainTime = 15.0f; // 남은 시간 (0이 되면 웨이브가 증가함)

    public int lvl = 1; // 현재 게임 레벨 (경험치로 상승함)

    public int nexusHp = 100; // 넥서스(Enemy의 최종 타겟)의 체력

    public int maxNexusHp = 100;


    // 게임에서 업그레이드 가능한 전체적인 능력. 업그레이드 시 해당 변수를 변경시키고, 기본값에 이 값을 곱해서 최종 능력치를 결정한다.
    public float damageBonus = 1.0f;
    public float fireRateBonus = 1.0f;
    public float expBonus = 1.0f;
    public float goldBonus = 1.0f;

    public int towerInstallCost = 100;
    public GameObject installTower; // 설치할 타워

    public int damageBonusLvl, fireRateBonusLvl, expBonusLvl, goldBonusLvl;

    void Start()
    {
        gold = 200; // test code
        exp = 0;
        curStage = -1;
        lvl = 1;
        damageBonusLvl = 1;
        fireRateBonusLvl = 1;
        expBonusLvl = 1;
        goldBonusLvl = 1;

        damageBonus = 1.0f;
        fireRateBonus = 1.0f;
        expBonus = 1.0f;
        goldBonus = 1.0f;

        towerInstallCost = 100;

        maxNexusHp = 100;
        nexusHp = maxNexusHp;

        UIManager.Instance.towerUpgradeUI.SetActive(false);

        SoundManager.Instance.PlayMainTheme();
    }

    void Update()
    {
        // 게임이 시작된 후 15초마다 웨이브가 증가한다.
        remainTime -= Time.deltaTime;
        if (remainTime <= 0)
        {
            curStage++;
            remainTime = 15f;

            if (curStage % 30 == 29)
            {
                for (int i = 0; i < 6; i++)
                {
                    spawnData[i] = 0; // 보스 웨이브에서는 모든 적의 수를 0으로 설정
                }
                spawnData[6] = 1; // 보스 웨이브에서는 보스만 스폰
            }
            else
            {
                // 다음 웨이브의 적 스폰 데이터 설정
                for (int i = 0; i < 6; i++)
                {
                    spawnData[i] = ((curStage + (6 - i)) / 6) * 5; // 예시로, 웨이브가 5의 배수일 때마다 적의 수를 증가시킴
                }
                spawnData[6] = 0; // 보스 웨이브가 아닐 경우 보스는 스폰하지 않음
            }

            for (int i = 0; i < 7; i++)
            {
                spawnedCnt[i] = 0;
            }
            curTargetEnemy = 0;
            Invoke("SpawnEnemy", 1.0f);
        }
    }

    public void InstallTower()
    {
        if (gold >= towerInstallCost)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // 2D 좌표이므로 z 값을 0으로 설정
            GameObject newTower = Instantiate(installTower, mousePosition, Quaternion.identity);
            gold -= towerInstallCost;
            newTower.GetComponent<Tower>().towerLvl = Random.Range(1, lvl + 1); // 타워 레벨 초기화
            newTower.GetComponent<Tower>().damage = 1 * newTower.GetComponent<Tower>().towerLvl; // 타워의 공격력 초기화
            newTower.GetComponent<Tower>().upgradeCost = 50 * newTower.GetComponent<Tower>().towerLvl; // 타워의 업그레이드 비용 초기화
            Debug.Log("Tower installed");

            towerInstallCost += 100; // 타워 설치 비용 증가
        }
        else
        {
            Debug.Log("You don't have enough golds");
            ErrorMessageManager.Instance.ShowErrorMessage("You don't have enough gold (Cost : " + towerInstallCost.ToString() + " Gems)");
        }
    }

    // 웨이브에 따라 스폰되는 적을 생성하는 함수
    private void SpawnEnemy()
    {

        int totalEnemyCnt = 0;

        for (int i = 0; i < 7; i++) 
        {
            totalEnemyCnt += spawnData[i];
        }

        while (curTargetEnemy < 7 && spawnedCnt[curTargetEnemy] >= spawnData[curTargetEnemy])
        {
            curTargetEnemy++;
        }

        if (curTargetEnemy >= 7)
        {
            return;
        }

        GameObject newEnemy = Instantiate(enemy[curTargetEnemy]);
        newEnemy.GetComponent<Enemy>().maxHP = (int)(newEnemy.GetComponent<Enemy>().maxHP * Mathf.Pow(1.07f, curStage));
        newEnemy.GetComponent<Enemy>().currentHP = newEnemy.GetComponent<Enemy>().maxHP;

        // 만약 소환된 적이 보스라면, 보스 HP UI를 활성화한다.
        if (newEnemy.GetComponent<Enemy>() is BossEnemy)
        {
            // 보스 등장 시 UIManager를 통해 보스 전용 HP UI를 표시하고 초기화
            if (UIManager.Instance != null)
            {
                UIManager.Instance.UpdateBossHpUI(newEnemy.GetComponent<Enemy>().currentHP, newEnemy.GetComponent<Enemy>().maxHP);
            }
            else
            {
                Debug.LogError("UIManager 인스턴스를 찾을 수 없습니다. Boss HP UI를 초기화할 수 없습니다.");
            }
        }
        spawnedCnt[curTargetEnemy]++;

        Invoke("SpawnEnemy", 12f / totalEnemyCnt);
    }
    
    public void AddGold(int rewardGold)
    {
        gold += (int)(rewardGold * goldBonus);
    }

    public void AddExp(int rewardExp)
    {
        exp += (int)(rewardExp * expBonus);

        LevelUp();
    }

    public void DamageNexus(int damage)
    {
        nexusHp -= damage;
        if (nexusHp <= 0)
        {
            PlayerPrefs.SetInt("CurScore", curStage + 1);
            SoundManager.Instance.StopAllSounds();
            SceneManager.LoadScene("GameOverScene");
        }
    }

    public void LevelUp()
    {
        // TODO : 이곳에 레벨업 함수 구현
        // 레벨을 올리고, 레벨에 따라 maxNexusHp를 증가시킨다.

        while (exp >= 100 * lvl)
        {
            exp -= 100 * lvl;
            lvl++;
            maxNexusHp += 10;
            nexusHp += 10;
        }
        Debug.Log("Level Up! Current Level: " + lvl);
        Debug.Log("Current Nexus HP: " + nexusHp);
        Debug.Log("Max Nexus HP: " + maxNexusHp);
    }

    public void damageBonusLvlUp()
    {
        if (gold >= 100 * damageBonusLvl)
        {
            gold -= 100 * damageBonusLvl;
            damageBonusLvl++;
            damageBonus += 0.05f;
        }
        else
        {
            Debug.Log("You don't have enough gold");
            ErrorMessageManager.Instance.ShowErrorMessage("You don't have enough gold");
        }
    }

    public void fireRateBonusLvlUp()
    {
        if (gold >= 100 * fireRateBonusLvl)
        {
            gold -= 100 * fireRateBonusLvl;
            fireRateBonusLvl++;
            fireRateBonus += 0.05f;
        }
        else
        {
            Debug.Log("You don't have enough gold");
            ErrorMessageManager.Instance.ShowErrorMessage("You don't have enough gold");
        }
    }

    public void expBonusLvlUp()
    {
        if (gold >= 100 * expBonusLvl)
        {
            gold -= 100 * expBonusLvl;
            expBonusLvl++;
            expBonus += 0.05f;
        }
        else
        {
            Debug.Log("You don't have enough gold");
            ErrorMessageManager.Instance.ShowErrorMessage("You don't have enough gold");
        }
    }

    public void goldBonusLvlUp()
    {
        if (gold >= 100 * goldBonusLvl)
        {
            gold -= 100 * goldBonusLvl;
            goldBonusLvl++;
            goldBonus += 0.05f;
        }
        else
        {
            Debug.Log("You don't have enough gold");
            ErrorMessageManager.Instance.ShowErrorMessage("You don't have enough gold");
        }
    }

    
}
