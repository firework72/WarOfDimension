using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHP; // 최대 체력
    public float currentHP; // 현재 체력
    public float moveSpeed; // 이동 속도
    public int rewardGold; // 처치 시 획득 골드

    public int rewardExp; // 처치 시 획득 경험치

    public Transform[] pathPoints; // 이동 경로
    private int currentPathIndex = 0; // 현재 위치

    void Update()
    {
        MoveAlongPath();
    }

    protected virtual void MoveAlongPath()
    {
        if (currentPathIndex >= pathPoints.Length) return;

        Transform target = pathPoints[currentPathIndex];
        Vector3 dir = target.position - transform.position;
        transform.position += dir.normalized * moveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            currentPathIndex++;
        }
            
    }

    public virtual void TakeDamage(float damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        // 골드 지급
        GameManager.Instance.AddGold(rewardGold);
        GameManager.Instance.AddExp(rewardExp);

        // 파괴
        Destroy(gameObject);
    }


}

