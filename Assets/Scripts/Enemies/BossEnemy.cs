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

    protected override void Die()
    {
        base.Die();
    }
}
