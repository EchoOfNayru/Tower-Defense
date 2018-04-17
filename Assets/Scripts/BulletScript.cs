using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float speed;
    public GameObject target;
    public TowerScript towerShotFrom;

    Vector3 dir;

    void FixedUpdate()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        else
        {
            dir = (target.transform.position - transform.position).normalized;
            transform.position += dir * speed;
        }
    }
}
