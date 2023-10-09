using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
	[SerializeField] float m_MovingTurnSpeed = 360;
    [SerializeField] float m_StationaryTurnSpeed = 180;

    private Rigidbody rigidbod;
    private Animator animator;
    private float turnAmount;
    private float forwardAmount;

	public void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        animator.applyRootMotion = true;
        rigidbod = GetComponent<Rigidbody>();

        rigidbod.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    public void Move(Vector3 desiredVelocity)
    {
        // convert the world relative moveInput vector into a local-relative
        // turn amount and forward amount required to head in the desired
        // direction.
        if (desiredVelocity.magnitude > 1f)
        {
            desiredVelocity.Normalize();
        }
        desiredVelocity = transform.InverseTransformDirection(desiredVelocity);
        desiredVelocity = Vector3.ProjectOnPlane(desiredVelocity, Vector3.zero);
        turnAmount = Mathf.Atan2(desiredVelocity.x, desiredVelocity.z);
        forwardAmount = desiredVelocity.z;

        ApplyExtraTurnRotation();

        UpdateAnimator(desiredVelocity);
    }

    void UpdateAnimator(Vector3 move)
    {
        animator.SetFloat("Forward", forwardAmount, 0.1f, Time.deltaTime);
        animator.SetFloat("Turn", turnAmount, 0.1f, Time.deltaTime);
    }

    void ApplyExtraTurnRotation()
    {
        // help the character turn faster (this is in addition to root rotation in the animation)
        float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, forwardAmount);
        transform.Rotate(0, turnAmount * turnSpeed * Time.deltaTime, 0);
    }

    public void OnAnimatorMove()
    {
        // we implement this function to override the default root motion.
        // this allows us to modify the positional speed before it's applied.
        if (Time.deltaTime > 0)
        {
            Vector3 v = animator.deltaPosition / Time.deltaTime;

            // we preserve the existing y part of the current velocity.
            v.y = rigidbod.velocity.y;
            rigidbod.velocity = v;
        }
    }

	public void Stop()
	{
		forwardAmount = turnAmount = 0f;
		animator.SetFloat("Forward", forwardAmount, 0.0f, Time.deltaTime);
		animator.SetFloat("Turn", turnAmount, 0.0f, Time.deltaTime);
	}
}
