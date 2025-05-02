using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;
            }

            return _instance;
        }
    }
    public int gold; // 현재 골드
    public int exp; // 현재 경험치

    public int curStage; // 현재 진행 중인 스테이지

    public int lvl; // 현재 게임 레벨 (경험치로 상승함)

    public int nexusHp; // 넥서스(Enemy의 최종 타겟)의 체력

    public int maxNexusHp;


    // 게임에서 업그레이드 가능한 전체적인 능력. 업그레이드 시 해당 변수를 변경시키고, 기본값에 이 값을 곱해서 최종 능력치를 결정한다.
    public float damageBonus = 1.0f;
    public float fireRateBonus = 1.0f;
    public float expBonus = 1.0f;
    public float goldBonus = 1.0f;

    public int damageBonusLvl, fireRateBonusLvl, expBonusLvl, goldBonusLvl;

    void Start()
    {
        damageBonusLvl = 1;
        fireRateBonusLvl = 1;
        expBonusLvl = 1;
        goldBonusLvl = 1;

        maxNexusHp = 100;
        nexusHp = maxNexusHp;
    }

    void Update()
    {
        
    }

    public void AddGold(int rewardGold)
    {
        gold += (int)(rewardGold * goldBonus);
    }

    public void AddExp(int rewardExp)
    {
        exp += (int)(rewardExp * expBonus);

        /* TODO : 현재 경험치 양에 따라 레벨을 변경하는 로직 구현 */
    }

    public void DamageNexus(int damage) {
        nexusHp -= damage;
        if (nexusHp <= 0)
        {
            // TODO : 게임 오버
            // SceneManager.LoadScene("GameOverScene");
        }
    }

    public void LevelUp()
    {
        // TODO : 이곳에 레벨업 함수 구현
        // 레벨을 올리고, 레벨에 따라 maxNexusHp를 증가시킨다.
    }
}

