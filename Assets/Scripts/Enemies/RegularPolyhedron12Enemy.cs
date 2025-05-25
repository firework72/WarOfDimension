using UnityEngine;

public class RegularPolyhedron12Enemy : Enemy
{
    protected override void Awake()
    {
        maxHP = 45;
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

    public override void TakeDamage(int damage)
    {
        if (Random.RandomRange(0.0f, 1.0f) < 0.3f) // 30% chance to dodge the attack
        {
            Debug.Log("Attack dodged!");
            return;
        }
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    protected override void Die()
    {
        base.Die();
    }
}
