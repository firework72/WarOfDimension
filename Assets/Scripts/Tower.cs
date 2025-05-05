using UnityEngine;
using System.Collections.Generic;

public class Tower : MonoBehaviour
{
    public int towerLvl;
    public float attackRange = 5f;      // 공격 범위
    public float fireRate = 1f;         // 초당 공격 횟수
    public int damage = 10;             // 한 발당 데미지
    public int upgradeCost = 50;        // 업그레이드 비용
    public GameObject nextTower;        // 업그레이드 시 다음 레벨의 타워

    private float fireCooldown = 0f;

    public int targetCnt = 0;

    public Transform firePoint;         // 발사 위치
    public GameObject bulletPrefab;     // 발사할 탄환
    public UIManager uiManager; // UI 매니저

    protected virtual void Update()
    {
        fireCooldown -= Time.deltaTime;

        List<Enemy> target = FindNearestEnemy(targetCnt);
        if (target != null && fireCooldown <= 0f)
        {
            Attack(target);
            fireCooldown = 1f / (fireRate * GameManager.Instance.fireRateBonus);
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

        // 범위 내 있는 적들 중 가장 멀리 간 적을 몇 개 골라내기 위해 moveDistance를 기준으로 내림차순 정렬한다.
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

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UIManager.Instance.ShowTowerUpgradeUI(this);
            Debug.Log("Tower clicked: " + gameObject.name);
        }
    }

    // 타워를 업그레이드하는 함수
    public void Upgrade()
    {
        if (nextTower != null)
        {
            if (GameManager.Instance.gold >= upgradeCost)
            {
                GameManager.Instance.gold -= upgradeCost;
                Vector3 pos = transform.position;
                Instantiate(nextTower, pos, Quaternion.identity); // Instantiate the firePoint at the tower's position
                Destroy(gameObject); // Destroy the current tower
            }
            else
            {
                Debug.Log("Not enough gold to upgrade!");
            }
        }
        else
        {
            Debug.Log("No next tower available for upgrade!");
        }
    }
}
