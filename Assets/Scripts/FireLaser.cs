using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLaser : MonoBehaviour
{
    private float lastFire;
    [SerializeField] private float fireRate;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > lastFire + fireRate)
        {
            lastFire = Time.time;
            SpawnLaserFromPool();
        }
    }

    void SpawnLaserFromPool()
    {
        var laser = ProjectilePool.Instance.GetFromPool();
        laser.transform.position = transform.position;
        laser.transform.rotation = transform.rotation;
    }
}
