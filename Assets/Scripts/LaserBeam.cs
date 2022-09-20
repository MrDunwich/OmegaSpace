using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    [SerializeField] private float speed = 70f;
    private float endOfLife;
    private float mass = 10f;
    private int frameCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        endOfLife = Time.time + (150f / speed);
    }

    private void OnEnable()
    {
        endOfLife = Time.time + (150f / speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > endOfLife) ProjectilePool.Instance.AddToPool(gameObject);

        RaycastHit hit;

        if (frameCounter == 1)
        {
            ProjectilePool.Instance.AddToPool(gameObject);
            frameCounter = 0;
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Time.deltaTime * speed)) {
            if (hit.rigidbody == null)
            {
                ProjectilePool.Instance.AddToPool(gameObject);
                return;
            }
            hit.rigidbody.AddForceAtPosition(mass * speed * transform.forward, hit.point);
            SimpleEnemy enemy = hit.collider.GetComponent<SimpleEnemy>();
            if (enemy) enemy.damage(100f);
            frameCounter++;
        }
        else transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
