using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    private float lastFire;
    public float fireRate;

    // Update is called once per frame
    public void Fire()
    {
        if (Time.time > lastFire + fireRate)
        {
            lastFire = Time.time;
            SpawnLaserFromPool();
        }
    }

    void SpawnLaserFromPool()
    {
        var laser = EnemyPPool.Instance.GetFromPool();
        laser.transform.position = transform.position;
        laser.transform.rotation = transform.rotation;
    }
}
