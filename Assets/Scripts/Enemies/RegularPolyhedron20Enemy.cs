using UnityEngine;

public class RegularPolyhedron20Enemy : Enemy
{
    protected override void Awake()
    {
        maxHP = 50;
        currentHP = maxHP;
        damage = 1;
        moveSpeed = 0.8f;
        rewardGold = 70;
        rewardExp = 70;

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
