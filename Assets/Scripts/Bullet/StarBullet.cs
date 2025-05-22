using UnityEngine;

public class StarBullet : Bullet
{
    public Transform targetTransform;
    public float dropDuration = 1f;
    public float aoeRadius = 2f;
    public LayerMask enemyLayer;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private float timer = 0f;
    private bool initialized = false;

    public void SetTarget(Enemy enemy, int dmg)
    {
        base.SetTarget(enemy, dmg);
        this.targetTransform = enemy.gameObject.transform;
        transform.position = targetTransform.position + Vector3.up * 10f;
        
        startPosition = targetTransform.position + Vector3.up * 10f;
        endPosition = targetTransform.position;
        transform.position = startPosition;
        timer = 0f;
        initialized = true;

        Debug.Log("StarBullet Spawned, Target : " + enemy.GetType().ToString());
    }

    void Update()
    {
        if (!initialized) return;

        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / dropDuration);
        transform.position = Vector3.Lerp(startPosition, endPosition, t);

        if (t >= 1f)
        {
            // 광역 대미지
            Collider[] hitEnemies = Physics.OverlapSphere(endPosition, aoeRadius, enemyLayer);
            foreach (var col in hitEnemies)
            {
                Enemy enemy = col.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
            Instantiate(hitEffect, endPosition, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (targetTransform != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(targetTransform.position, aoeRadius);
        }
    }
}
