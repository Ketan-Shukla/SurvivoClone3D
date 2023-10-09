using System;
using System.Collections;
using UnityEngine;

public class PistolBullet : BulletBase
{
    private void OnEnable()
    {
        StartCoroutine(ReturnToPoolTimer());
    }

    protected override void OnTriggerEnter(Collider collision)
    {
        base.OnTriggerEnter(collision);
        //PistolBulletPool.Instance.ReturnToPool(this);
    }

    public IEnumerator ReturnToPoolTimer()
    {
        yield return new WaitForSeconds(DeathTimer);
        PistolBulletPool.Instance.ReturnToPool(this);
    }

}