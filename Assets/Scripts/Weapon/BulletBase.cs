using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBase : MonoBehaviour, IDeathTimer
{
    [SerializeField] protected float damage;
    [SerializeField] protected float speed;
    public string bulletOrigin = "";
    [field: SerializeField] public float DeathTimer { get; set; }


    private void Update()
    {
        Move();
    }

    protected void Move()
    {
        transform.position += transform.right * (speed * Time.deltaTime);
    }


    protected virtual void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.TryGetComponent(out IPlayerCanHit hitable))
        {
            if(collision.tag== bulletOrigin) { return; }
            hitable?.Hit();

            if (collision.gameObject.TryGetComponent(out IHealth health))
            {
                health?.TakeDamage(damage);


                health?.CheckHealth();

            }
        }


    }
}
