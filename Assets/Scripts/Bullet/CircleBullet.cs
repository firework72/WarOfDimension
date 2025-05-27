using UnityEngine;

public class CircleBullet : Bullet
{
    void SetTarget(Enemy enemy, int dmg)
    {
        base.SetTarget(enemy, dmg);
    }

    void Update()
    {
        base.Update();
        if (Vector3.Distance(transform.position, target.transform.position) < 0.1f)
        {
            if (target is CircleEnemy)
            {
                target.TakeDamage(damage * 5);
            }
            else
            {
                target.TakeDamage(damage);
            }
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }   
    }
}
