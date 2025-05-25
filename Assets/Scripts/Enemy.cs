using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHP; // 최대 체력
    public int currentHP; // 현재 체력
    public int damage; // 넥서스에 입히는 대미지
    public float moveSpeed; // 이동 속도
    public int rewardGold; // 처치 시 획득 골드

    public int rewardExp; // 처치 시 획득 경험치

    public Transform[] pathPoints; // 이동 경로
    private int currentPathIndex = 0; // 현재 위치

    public float moveDistance = 0.0f; // 현재까지 이동한 거리

    public GameObject hpText;

    protected virtual void Awake()
    {
        // 이동 경로를 정하는 코드로, 추후 수정할 수 있다.
        pathPoints = new Transform[23];
        for (int i = 0; i < pathPoints.Length; i++)
        {
            pathPoints[i] = GameObject.Find("PathGroup").transform.GetChild(i).transform;
        }

        transform.position = pathPoints[0].position;

        hpText = transform.Find("HpTextContainer").gameObject.transform.Find("HpText").gameObject;
    }

    protected virtual void Update()
    {
        MoveAlongPath();
        hpText.GetComponent<TextMeshPro>().text = currentHP.ToString();
    }

    protected virtual void MoveAlongPath()
    {
        if (currentPathIndex >= pathPoints.Length) return;

        Transform target = pathPoints[currentPathIndex];
        Vector3 dir = target.position - transform.position;
        transform.position += dir.normalized * moveSpeed * Time.deltaTime;
        moveDistance += moveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            currentPathIndex++;
            if (currentPathIndex >= pathPoints.Length)
            {
                GameManager.Instance.DamageNexus(damage);
                Destroy(gameObject);
            }
        }
            
    }

    public virtual void TakeDamage(int damage)
    {
        currentHP -= damage;
        SoundManager.Instance.PlayHitSound();
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

        SoundManager.Instance.PlayDieSound();
        // 파괴
        Destroy(gameObject);
    }


}

