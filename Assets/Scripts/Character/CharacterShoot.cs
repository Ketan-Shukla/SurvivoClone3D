using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterShoot : MonoBehaviour
{

    [SerializeField] private Transform bulletSpawnPos;
    [SerializeField] private BaseWeapon currentWeapon;

    private float timeOfLastFiring = 0f;
    private CharacterMovement characterController;

    GameObject destination;
    int enemiesInZone = 0;
    void Start()
    {
        characterController = FindObjectOfType<CharacterMovement>();
        destination = characterController.gameObject;
        enemiesInZone = 0;
    }

    void Update()
    {
        //bulletSpawnPos.LookAt(destination.transform, Vector3.left);
        FireControl();

    }

    public void FireControl()
    {
        if (Time.time >= timeOfLastFiring + currentWeapon.fireRate && enemiesInZone>0)
        {
            Shoot();
            timeOfLastFiring = Time.time;
        }

    }

    private void Shoot()
    {
        currentWeapon.SpawnBullet(bulletSpawnPos, "Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy")
        {
            enemiesInZone += 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "enemy")
        {
            enemiesInZone -= 1;
        }
    }
}
