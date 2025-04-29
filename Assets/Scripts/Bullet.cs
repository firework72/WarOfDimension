using UnityEngine;


public class Bullet : MonoBehaviour
{
    private Enemy target;
    private int damage;
    public float speed = 10f;

    public void SetTarget(Enemy enemy, int dmg)
    {
        target = enemy;
        damage = dmg;
    }

    void Update()
    {
        if (target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
        transform.position += dir.normalized * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.transform.position) < 0.1f)
        {
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
