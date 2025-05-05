using UnityEngine;

public class RegularPolyhedron4Enemy : Enemy
{
    protected override void Awake()
    {
        maxHP = 20 * (int)(Mathf.Pow(5, GameManager.Instance.curStage / 30));
        currentHP = maxHP;
        damage = 1;
        moveSpeed = 0.6f;
        rewardGold = 15;
        rewardExp = 15;

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
