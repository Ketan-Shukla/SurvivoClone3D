using System;
using System.Collections;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{

    public float spawnInterval = 2.0f;
    public float spawnDistance = 10.0f;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        for (int i = 0; i < spawnDistance; i++) {
            StartSpawnEnemy();
        }
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {

            Vector3 spawnDirection = GetRandomSpawnDirection();


            Vector3 spawnPosition = mainCamera.ViewportToWorldPoint(spawnDirection);
            spawnPosition.z = 0;
            spawnPosition = spawnPosition.normalized * spawnDistance;
            if(UnityEngine.Random.Range(0, 2)==0)
            {
                var enemy = EnemyPool.Instance.GetObject();
                enemy.transform.position = spawnPosition;
                enemy.gameObject.SetActive(true);
            }
            else
            {
                var enemy = EnemyShooterPool.Instance.GetObject();
                enemy.transform.position = spawnPosition;
                enemy.gameObject.SetActive(true);
            }

            

            yield return new WaitForSeconds(spawnInterval);
        
    }

    private Vector3 GetRandomSpawnDirection()
    {
        int randomSide = UnityEngine.Random.Range(0, 4);

        switch (randomSide)
        {
            case 0: return new Vector3(UnityEngine.Random.value,0 , spawnDistance);
            case 1: return new Vector3(UnityEngine.Random.Range(-10, 10), 0, spawnDistance);
            case 2: return new Vector3(UnityEngine.Random.Range(-30,30), 0, spawnDistance);
            case 3: return new Vector3(UnityEngine.Random.Range(-50, 50), 0, spawnDistance);
            default: return Vector3.zero;
        }
    }

    public void StartSpawnEnemy()
    {
        StartCoroutine(SpawnEnemies());
    }


}
