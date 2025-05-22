using UnityEngine;

public class TriangleBullet : Bullet
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
            if (target is RegularPolyhedron4Enemy || target is RegularPolyhedron8Enemy || target is RegularPolyhedron20Enemy)
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
