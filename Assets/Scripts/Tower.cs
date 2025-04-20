using UnityEngine;

public class Tower : MonoBehaviour
{
    public float attackRange = 5f;      // 공격 범위
    public float fireRate = 1f;         // 초당 공격 횟수
    public int damage = 10;             // 한 발당 데미지
    public int upgradeCost = 50;        // 업그레이드 비용

    private float fireCooldown = 0f;

    public Transform firePoint;         // 발사 위치
    public GameObject bulletPrefab;     // 발사할 탄환

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        Enemy target = FindNearestEnemy();
        if (target != null && fireCooldown <= 0f)
        {
            Attack(target);
            fireCooldown = 1f / fireRate;
        }
    }

    // 공격해야 할 적을 탐색하는 함수 (현재는 가장 가까운 적을 타겟팅하도록 되어 있음. 나중에 가장 멀리 간 적을 타겟팅하는 방향도 고려 중)
    Enemy FindNearestEnemy()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
        Enemy nearest = null;
        float shortestDist = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (dist < shortestDist && dist <= attackRange)
            {
                shortestDist = dist;
                nearest = enemy;
            }
        }

        return nearest;
    }

    // 실제로 탄환을 발사하는 함수
    protected virtual void Attack(Enemy target)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetTarget(target, damage);
    }

}
