using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCharacter : MonoBehaviour , IPlayerCanHit, IHealth
{
    [SerializeField] GameObject coinSpawn;
    [SerializeField] GameObject healthSpawn;
    [SerializeField] GameObject coinSpawnLocation;
    private NavMeshAgent navAgent;
    private int maxHealth = 25;
    private float health;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        SetHealth(maxHealth);

        // health = maxHealth;
    }

    public void SetHealth(float newHealth)
    {
        health = newHealth;
        health = Mathf.Min(health, maxHealth);
        health = Mathf.Max(health, 0);
    }

    public void BoostHealth()
    {

    }

    public void TakeDamage()
    {
        health -= 20;
        health = Mathf.Max(health, 0);
    }

    public void Hit()
    {
        TakeDamage();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Max(health, 0);

    }

    public void CheckHealth()
    {
        if (health <= 0)
        {
            if(Random.Range(0,2)== 0)
            {
                var gameObject = Instantiate(coinSpawn, coinSpawnLocation.transform.position, Quaternion.identity);
                gameObject.SetActive(true);
            }
            else
            {
                var gameObject = Instantiate(healthSpawn, coinSpawnLocation.transform.position, Quaternion.identity);
                gameObject.SetActive(true);
            }

            Invoke("DestroyEnemy", 1f);
        }
    }

    void DestroyEnemy()
    {
        GetComponent<NavMeshAgent>().isStopped = true;
        if(GetComponent<EnemyShoot>() != null )
        {
            EnemyShooterPool.Instance.ReturnToPool(GetComponent<EnemyShoot>());
            return;
        }
        EnemyPool.Instance.ReturnToPool(this);

    }

    public int MaxHealth
    {
        get { return maxHealth; }
    }

    public float Health
    {
        get { return health; }
    }
}
