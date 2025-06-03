using UnityEngine;

public class BossEnemy : Enemy
{
    protected override void Awake()
    {
        maxHP = 1000;
        currentHP = maxHP;
        damage = 200;
        moveSpeed = 0.4f;
        rewardGold = 1000;
        rewardExp = 1000;

        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void MoveAlongPath()
    {
        base.MoveAlongPath();
    }

    public override void TakeDamage(int damageAmount)
    {
        base.TakeDamage(damageAmount);

        // UIManager를 통해 보스 HP UI 업데이트
        if (UIManager.Instance != null)
        {
            if (currentHP > 0)
            {
                UIManager.Instance.UpdateBossHpUI(currentHP, maxHP);
            }
        }
    }

    protected override void Die()
    {
        GameManager.Instance.nexusHp += 50; // 보스 처치 시 넥서스 HP 회복
        base.Die();
    }

    void OnDestroy()
    {
        if (UIManager.Instance != null)
        {
            UIManager.Instance.HideBossHpUI();
        }
        else
        {
            Debug.LogError("UIManager 인스턴스를 찾을 수 없습니다. Boss HP UI를 숨길 수 없습니다.");
        }
    }
}
