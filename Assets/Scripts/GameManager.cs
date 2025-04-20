using UnityEngine;

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

    public void AddGold(int rewardGold)
    {
        gold += rewardGold;
    }

    public void AddExp(int rewardExp)
    {
        exp += rewardExp;

        /* TODO : 현재 경험치 양에 따라 레벨을 변경하는 로직 구현 */
    }
}

