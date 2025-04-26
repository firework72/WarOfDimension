using UnityEngine;

public class CircleTower : Tower
{
    void Awake()
    {
        attackRange = 3.0f;
        fireRate = 1.0f;
        damage = 1;
        upgradeCost = 50;
        firePoint = gameObject.transform;
    }

    protected override void Update()
    {
        base.Update();
    }

    public override Enemy FindNearestEnemy()
    {
        return base.FindNearestEnemy();
    }

    public override void Attack(Enemy target)
    {
        base.Attack(target);
    }
}