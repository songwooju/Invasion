using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;
    public float fireRate = 0.2f;

    private float fireTimer = 0f;

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (Input.GetButton("Fire1") && fireTimer >= fireRate)
        {
            Fire();
            fireTimer = 0f;
        }

        void Fire()
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);


            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                bulletRigidbody.velocity = -bulletSpawnPoint.forward * bulletSpeed;
            }

            Destroy(bullet, 2f);
        }
    }
}