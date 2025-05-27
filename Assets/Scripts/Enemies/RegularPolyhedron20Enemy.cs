using UnityEngine;

public class RegularPolyhedron20Enemy : Enemy
{
    public GameObject regularPolyhedron8Enemy;
    protected override void Awake()
    {
        maxHP = 50;
        currentHP = maxHP;
        damage = 1;
        moveSpeed = 0.8f;
        rewardGold = 70;
        rewardExp = 70;

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
        for (int i = 0; i < 2; i++)
        {
            GameObject newEnemy = Instantiate(regularPolyhedron8Enemy, transform.position, Quaternion.identity);
            newEnemy.GetComponent<Enemy>().currentPathIndex = currentPathIndex;
            newEnemy.GetComponent<Enemy>().moveDistance = moveDistance;
            newEnemy.transform.position = transform.position;
            newEnemy.GetComponent<Enemy>().maxHP = maxHP * 3 / 5;
            newEnemy.GetComponent<Enemy>().currentHP = maxHP * 3 / 5;
        }

        // ��� ����
        GameManager.Instance.AddGold(rewardGold);
        GameManager.Instance.AddExp(rewardExp);

        SoundManager.Instance.PlayDieSound();

        // �ı�
        Destroy(gameObject);
    }
}
