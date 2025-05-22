using System.Collections.Generic;
using UnityEngine;

public class StarTower : Tower
{
    void Awake()
    {
        attackRange = 99.0f;
        fireRate = 0.1f;
        damage = 10 * towerLvl;
        targetCnt = 1;
        upgradeCost = 10000000;
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
