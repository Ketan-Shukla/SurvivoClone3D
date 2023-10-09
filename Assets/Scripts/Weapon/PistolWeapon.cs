using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Pistol")]
public class PistolWeapon : BaseWeapon
{

    private void Awake()
    {
    }
    public override void SpawnBullet(Transform bulletSpawnPos, string origin)
    {
        var bullet = PistolBulletPool.Instance.GetObject();
        Debug.Log("SpawnBullet "+bullet.name);
        bullet.GetComponent<BulletBase>().bulletOrigin=(origin);
        bullet.transform.SetPositionAndRotation(bulletSpawnPos.position, bulletSpawnPos.rotation);
        bullet.gameObject.SetActive(true);
    }

}
