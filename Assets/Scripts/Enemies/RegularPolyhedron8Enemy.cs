using UnityEngine;

public class RegularPolyhedron8Enemy : Enemy
{
    protected override void Awake()
    {
        maxHP = 30 * (int)(Mathf.Pow(5, GameManager.Instance.curStage / 30));
        currentHP = maxHP;
        damage = 1;
        moveSpeed = 0.7f;
        rewardGold = 40;
        rewardExp = 40;

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
