using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovement : MonoBehaviour
{ 

    private Rigidbody rigidbod;
    private Animator animator;
    private float turnAmount;
    private float forwardAmount;
    private Vector3 movement = Vector3.zero;
    private CharacterMovement characterController;
    private NavMeshAgent enemyAI;
    GameObject destination;

    public void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        animator.applyRootMotion = true;
        rigidbod = GetComponent<Rigidbody>();

        rigidbod.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    public void Start()
    {
        characterController = FindObjectOfType<CharacterMovement>();
        enemyAI = GetComponent<NavMeshAgent>();
        destination = characterController.gameObject;
    }

    public void Move()
    {
        if(enemyAI.isActiveAndEnabled) {
        enemyAI.SetDestination(destination.transform.position);
        }
    }

    void Update()
    {
  
        Move();
        
    }

    void OnTriggerEnter(Collider col)
    {
        if( col.tag == "Player")
        {
            col.gameObject.GetComponent<CharacterController>().Hit();
        }
    }
 
}
