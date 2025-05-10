using System.Collections.Generic;
using UnityEngine;

public class CircleTower : Tower
{
    void Awake()
    {
        attackRange = 3.0f;
        fireRate = 1.0f;
        damage = 1 * towerLvl;
        targetCnt = 1;
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