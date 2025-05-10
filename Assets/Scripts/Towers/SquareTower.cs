using System.Collections.Generic;
using UnityEngine;

public class SquareTower : Tower
{
    void Awake()
    {
        attackRange = 5.0f;
        fireRate = 4.0f;
        damage = 1 * towerLvl;
        targetCnt = 4;
        upgradeCost = 200;
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
