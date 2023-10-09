using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : ScriptableObject
{

    public float fireRate;
    public abstract void SpawnBullet(Transform bulletSpawnPos, string origin);
}
