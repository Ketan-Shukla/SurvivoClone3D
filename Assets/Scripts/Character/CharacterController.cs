using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour, IPlayerCanHit, IHealth
{
	private CharacterMovement characterMovement;
	private NavMeshAgent navAgent;
	private int maxHealth = 5000;
	private float health;
	private PlayerInput pi;
	private BoxCollider colliderBox;

    [SerializeField] private Transform bulletSpawnPos;


    void Start()
    {
		characterMovement = GetComponent<CharacterMovement>();
		navAgent = GetComponent<NavMeshAgent>();
		pi = GetComponent<PlayerInput>();
		colliderBox = GetComponent<BoxCollider>();
		// health = maxHealth;
	}

    void Update()
    {
		Vector3 movement = Vector3.zero;

		Vector2 touchIP = pi.actions["Move"].ReadValue<Vector2>();
        movement = new Vector3(touchIP.x, 0, touchIP.y);
        characterMovement.Move(movement);
    }

	public void SetHealth(int newHealth)
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

            Invoke("DestroyPlayer", 1f);
        }
    }

    void DestroyPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

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
