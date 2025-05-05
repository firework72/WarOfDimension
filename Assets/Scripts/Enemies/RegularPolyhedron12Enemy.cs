using UnityEngine;

public class RegularPolyhedron12Enemy : Enemy
{
    protected override void Awake()
    {
        maxHP = 45 * (int)(Mathf.Pow(5, GameManager.Instance.curStage / 30));
        currentHP = maxHP;
        damage = 1;
        moveSpeed = 0.75f;
        rewardGold = 50;
        rewardExp = 50;

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
