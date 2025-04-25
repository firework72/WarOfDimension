using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject startPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Spawn", 1.0f);
    }

    void Spawn()
    {
        GameObject newEnemy = Instantiate(enemyPrefab);
        newEnemy.transform.position = new Vector3(-9, 0, 0);
        Invoke("Spawn", 1.0f);
    }

}
