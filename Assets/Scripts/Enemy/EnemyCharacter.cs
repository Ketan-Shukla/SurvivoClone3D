using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCharacter : MonoBehaviour , IPlayerCanHit, IHealth
{
    [SerializeField] GameObject coinSpawn;
    [SerializeField] GameObject coinSpawnLocation;
    private NavMeshAgent navAgent;
    private int maxHealth = 50;
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
        health += 10;
        health = Mathf.Min(health, maxHealth);
    }

    public void TakeDamage()
    {
        health -= 10;
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
            Instantiate(coinSpawn, coinSpawnLocation.transform.position, Quaternion.identity);

            Invoke("DestroyEnemy", 1f);
        }
    }

    void DestroyEnemy()
    {
        GetComponent<NavMeshAgent>().isStopped = true;
        Destroy(gameObject);

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
