using System.Collections.Generic;
using UnityEngine;

public class PentagonTower : Tower
{
    void Awake()
    {
        attackRange = 6.0f;
        fireRate = 5.0f;
        damage = 1 * towerLvl;
        targetCnt = 5;
        upgradeCost = 400;
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
