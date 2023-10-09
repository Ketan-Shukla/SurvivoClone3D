using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyShoot : MonoBehaviour
{

    [SerializeField] private BaseWeapon currentWeapon;
    private float timeOfLastFiring = 0f;
    [SerializeField] private Transform bulletSpawnPos;
    private CharacterMovement characterController;
    GameObject destination;
    void Start()
    {
        characterController = FindObjectOfType<CharacterMovement>();
        destination = characterController.gameObject;
    }

    void Update()
    {
        //bulletSpawnPos.LookAt(destination.transform, Vector3.left);
        FireControl();

    }

    public void FireControl()
    {
        if (Time.time >= timeOfLastFiring + currentWeapon.fireRate)
        {
            Shoot();
            timeOfLastFiring = Time.time;
        }

    }

    private void Shoot()
    {
        Debug.Log("Shoot");
        
        transform.LookAt(destination.transform.position, transform.up);

        currentWeapon.SpawnBullet(bulletSpawnPos,"enemy");
    }
}
