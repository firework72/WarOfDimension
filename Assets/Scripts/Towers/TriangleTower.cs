using System.Collections.Generic;
using UnityEngine;

public class TriangleTower : Tower
{
    void Awake()
    {
        attackRange = 4.0f;
        fireRate = 1.0f;
        damage = 1;
        targetCnt = 3;
        upgradeCost = 50;
        firePoint = gameObject.transform;
    }

    protected override void Update()
    {
        base.Update();
    }

    public override List<Enemy> FindNearestEnemy(int targetCnt)
    {
        return base.FindNearestEnemy(targetCnt);
    }

    public override void Attack(List<Enemy> target)
    {
        base.Attack(target);
    }
}