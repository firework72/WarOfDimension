using UnityEngine;

public class StarBullet : Bullet
{
    public float dropDuration = 1f;
    public float aoeRadius = 2f;
    public LayerMask enemyLayer;

    public Transform targetTransform;
    public Vector3 targetTransformPos;

    public override void SetTarget(Enemy enemy, int dmg)
    {
        base.SetTarget(enemy, dmg);
        if (enemy == null || target == null)
        {
            Destroy(gameObject);
            return;
        }
        targetTransform = target.transform;
        targetTransformPos = targetTransform.position;
        speed = 3f;
    }

    public override void Update()
    {
        // 초마다 270도씩 회전하는 애니메이션 적용
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 270f * Time.deltaTime);

        Vector3 dir = targetTransformPos - transform.position;
        transform.position += dir.normalized * (speed * Vector3.Distance(transform.position, targetTransformPos)) * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetTransformPos) < 0.1f)
        {
            // 광역 대미지  
            Collider[] hitEnemies = Physics.OverlapSphere(transform.position, aoeRadius, enemyLayer);
            Debug.Log(hitEnemies.Length + " enemies hit.");
            foreach (var col in hitEnemies)
            {
                Enemy enemy = col.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }

            Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(targetTransformPos, aoeRadius);
    }
}
