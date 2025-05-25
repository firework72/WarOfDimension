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
        // ��� �� 4��ü �� 2���� ��ȯ
        for (int i = 0; i < 2; i++)
        {
            GameObject newEnemy = Instantiate(regularPolyhedron4Enemy, transform.position, Quaternion.identity);
            newEnemy.GetComponent<Enemy>().maxHP = maxHP * 2 / 3;
            newEnemy.GetComponent<Enemy>().currentHP = maxHP * 2 / 3;
        }

        // ��� ����
        GameManager.Instance.AddGold(rewardGold);
        GameManager.Instance.AddExp(rewardExp);

        SoundManager.Instance.PlayDieSound();

        // �ı�
        Destroy(gameObject);
    }
}
