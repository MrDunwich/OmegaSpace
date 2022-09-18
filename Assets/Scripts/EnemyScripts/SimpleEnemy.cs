using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    public float torque = 5f;
    public float thrust = 80000f;
    private Rigidbody rb;
    public Transform player;

    public EnemyFire weapon;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Fly();
    }

    void Fly()
    {
        Vector3 targetDir = player.position - transform.position;

        float xyAngle = vector3AngleOnPlane(player.position, transform.position, transform.forward, transform.up);
        float yzAngle = vector3AngleOnPlane(player.position, transform.position, transform.right, transform.forward);

        if(Mathf.Abs(xyAngle) >= 1f && Math.Abs(yzAngle) >= 1f)
        {
            rb.AddRelativeTorque(Vector3.forward * -torque * (xyAngle / Mathf.Abs(xyAngle)));
        }
        else if (yzAngle > 1f)
        {
            rb.AddRelativeTorque(Vector3.right * -torque);

            weapon.Fire();
        }

        rb.AddRelativeForce(Vector3.forward * thrust);
    }

    private float vector3AngleOnPlane(Vector3 from, Vector3 to, Vector3 planeNormal, Vector3 toOrientation)
    {
        Vector3 projectedVector = Vector3.ProjectOnPlane(from - to, planeNormal);
        float projectedVectorAngle = Vector3.SignedAngle(projectedVector, toOrientation, planeNormal);

        return projectedVectorAngle;
    }
}
