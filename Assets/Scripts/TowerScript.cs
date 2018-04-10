using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour {

    public GameObject bullet;
    public float shootInterval;
    public float damage;
    public float bulletSpeed;

    GameObject currentTarget;
    BasicEnemy targetEnemy;
    float timer;

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= shootInterval)
        {
            ShootAtEnemy(currentTarget);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        targetEnemy = other.GetComponent<BasicEnemy>();
        if (targetEnemy != null)
        {
            timer = shootInterval;
            currentTarget = targetEnemy.gameObject;
        }
    }

    void ShootAtEnemy(GameObject target)
    {
        GameObject tempBullet = Instantiate(bullet);
        Rigidbody tempRB = tempBullet.GetComponent<Rigidbody>();
        Vector3 targetVector3 = target.transform.position;
        tempRB.AddForce(targetVector3 * bulletSpeed, ForceMode.Impulse);
    }
}
