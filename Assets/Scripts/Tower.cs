using UnityEngine;
using System.Collections.Generic;

public class Tower : MonoBehaviour
{
    public float attackRange = 5f;      // 공격 범위
    public float fireRate = 1f;         // 초당 공격 횟수
    public int damage = 10;             // 한 발당 데미지
    public int upgradeCost = 50;        // 업그레이드 비용

    private float fireCooldown = 0f;

    public int targetCnt = 0;

    public Transform firePoint;         // 발사 위치
    public GameObject bulletPrefab;     // 발사할 탄환

    protected virtual void Update()
    {
        fireCooldown -= Time.deltaTime;

        List<Enemy> target = FindNearestEnemy(targetCnt);
        if (target != null && fireCooldown <= 0f)
        {
            Attack(target);
            fireCooldown = 1f / fireRate;
        }
    }

    // 공격해야 할 적을 탐색하는 함수 (기본적으로 가장 멀리 간 타겟을 공격)
    public virtual List<Enemy> FindNearestEnemy(int targetCnt)
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();

        List<Enemy> targetEnemies = new List<Enemy>();

        foreach (Enemy enemy in enemies)
        {
            float dist = Vector3.Distance(enemy.transform.position, firePoint.position);
            if (dist <= attackRange)
            {
                targetEnemies.Add(enemy);
            }
        }

        targetEnemies.Sort((a, b) => b.moveDistance.CompareTo(a.moveDistance));

        List<Enemy> returnValue = new List<Enemy>();

        for (int i = 0; i < Mathf.Min(targetCnt, targetEnemies.Count); i++)
        {
            returnValue.Add(targetEnemies[i]);
        }

        return returnValue;
    }

    // 실제로 탄환을 발사하는 함수
    public virtual void Attack(List<Enemy> target)
    {
        foreach (Enemy enemy in target)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().SetTarget(enemy, damage);
        }
        
    }

}
