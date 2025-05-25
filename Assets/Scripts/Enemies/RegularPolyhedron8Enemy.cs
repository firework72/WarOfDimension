using UnityEngine;

public class RegularPolyhedron8Enemy : Enemy
{
    public GameObject regularPolyhedron4Enemy;
    protected override void Awake()
    {
        maxHP = 30;
        currentHP = maxHP;
        damage = 1;
        moveSpeed = 0.7f;
        rewardGold = 40;
        rewardExp = 40;

        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void MoveAlongPath()
    {
        base.MoveAlongPath();
    }

    protected override void Die()
    {
        // 사망 시 4면체 적 2마리 소환
        for (int i = 0; i < 2; i++)
        {
            GameObject newEnemy = Instantiate(regularPolyhedron4Enemy, transform.position, Quaternion.identity);
            newEnemy.GetComponent<Enemy>().maxHP = maxHP * 2 / 3;
            newEnemy.GetComponent<Enemy>().currentHP = maxHP * 2 / 3;
        }

        // 골드 지급
        GameManager.Instance.AddGold(rewardGold);
        GameManager.Instance.AddExp(rewardExp);

        // 파괴
        Destroy(gameObject);
    }
}
