using UnityEngine;

public class CircleEnemy : Enemy
{
    protected override void Awake()
    {
        maxHP = 15;
        currentHP = maxHP;
        damage = 1;
        moveSpeed = 1.0f;
        rewardGold = 10;
        rewardExp = 10;

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