using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour {

    List<GameObject> enemiesInRange = new List<GameObject>();

    public GameObject bullet;
    public float shootInterval;
    public float damage;
    public float bulletSpeed;
    public float towerRange;
    public float towerBulletSpawnHeight;

    GameObject currentTarget;
    BasicEnemy targetEnemy;
    float timer;

    void Start()
    {
        CapsuleCollider range = GetComponent<CapsuleCollider>();
        if (range != null)
        {
            range.radius = towerRange;
        }
    }

    void ShootAtEnemy(GameObject target)
    {
        GameObject tempBullet = Instantiate(bullet);
        tempBullet.transform.position = transform.position;
        tempBullet.transform.position = new Vector3(transform.position.x, transform.position.y + towerBulletSpawnHeight, transform.position.z);
        BulletScript tempBulletScript = tempBullet.GetComponent<BulletScript>();
        tempBulletScript.target = target;
    }

    void OnTriggerEnter(Collider other)
    {
        BasicEnemy enemyCheck = other.GetComponent<BasicEnemy>();
        if (enemyCheck != null)
        {
            // enemiesInRange[enemiesInRange.Count] = enemyCheck.gameObject;
            enemiesInRange.Add(enemyCheck.gameObject);
            ShootAtEnemy(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (enemiesInRange.Contains(other.gameObject))
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }
}
