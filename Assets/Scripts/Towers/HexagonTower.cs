using System.Collections.Generic;
using UnityEngine;

public class HexagonTower : Tower
{
    void Awake()
    {
        attackRange = 7.0f;
        fireRate = 6.0f;
        damage = 1;
        targetCnt = 6;
        upgradeCost = 1000;
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
