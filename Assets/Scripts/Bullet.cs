using UnityEngine;


public class Bullet : MonoBehaviour
{
    public Enemy target;
    public GameObject hitEffect;
    public int damage;
    public float speed = 10f;

    public virtual void SetTarget(Enemy enemy, int dmg)
    {
        target = enemy;
        damage = dmg;
    }

    public virtual void Update()
    {
        if (target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
        transform.position += dir.normalized * speed * Time.deltaTime;

        
    }
}
