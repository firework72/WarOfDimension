using UnityEngine;

public class RegularPolyhedron6Enemy : Enemy
{
    protected override void Awake()
    {
        maxHP = 40 * (int)(Mathf.Pow(5, GameManager.Instance.curStage / 30));
        currentHP = maxHP;
        damage = 1;
        moveSpeed = 0.65f;
        rewardGold = 25;
        rewardExp = 25;

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
