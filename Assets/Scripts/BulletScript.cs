using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float speed;
    public GameObject target;

    Vector3 dir;

    void FixedUpdate()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }

        dir = (target.transform.position - transform.position).normalized;
        transform.position += dir * speed;
    }
}
