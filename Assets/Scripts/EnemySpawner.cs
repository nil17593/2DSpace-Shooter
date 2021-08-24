using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float minY, maxY;

    [SerializeField] private GameObject [] asteroidPrefab;
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private float timer; 
    
    void Start()
    {
        Invoke("SpawnEnemies", timer);
    }

    void SpawnEnemies()
    {
        float posY = Random.Range(minY, maxY);
        Vector3 temp = transform.position;
        temp.y = posY;

        if (Random.Range(0, 2) > 0)
        {
            Instantiate(asteroidPrefab[Random.Range(0, asteroidPrefab.Length)], temp, Quaternion.identity);
        }
        else
        {
            Instantiate(enemyPrefab, temp, Quaternion.Euler(0f,0f,90f));
        }
        Invoke("SpawnEnemies", timer);
    }
 
}
