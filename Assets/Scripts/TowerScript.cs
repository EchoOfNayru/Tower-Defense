using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour {

    public List<GameObject> enemiesInRange = new List<GameObject>();

    public GameObject bullet;
    public float towerRange;
    public float towerBulletSpawnHeight;
    public float towerFireRate;
    public float towerDamage;

    float shootTimer;

    void Start()
    {
        CapsuleCollider range = GetComponent<CapsuleCollider>();
        if (range != null)
        {
            range.radius = towerRange;
        }
        
        shootTimer = 0;
    }

    void Update()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= towerFireRate)
        {
            // try to find an enemy we can shoot at
            for(int i = 0; i < enemiesInRange.Count; ++i)
            {
                // get rid of the null ones
                if(enemiesInRange[i] == null)
                {
                    enemiesInRange.RemoveAt(i);     // so we'll remove the null ones
                    i--;                            // and then -1 to the index because everything else shifted over to the left
                    continue;                       // and then moves to the next iteration of the loop
                }
                
                // shoot and then exit the loop
                shootTimer = 0;
                ShootAtEnemy(enemiesInRange[i]);
                break;
            }
        }
    }

    void ShootAtEnemy(GameObject target)
    {
        GameObject tempBullet = Instantiate(bullet);
        tempBullet.transform.position = transform.position;
        tempBullet.transform.position = new Vector3(transform.position.x, transform.position.y + towerBulletSpawnHeight, transform.position.z);
        BulletScript tempBulletScript = tempBullet.GetComponent<BulletScript>();
        tempBulletScript.target = target;
        tempBulletScript.towerShotFrom = this;
    }

    void OnTriggerEnter(Collider other)
    {
        BasicEnemy enemyCheck = other.GetComponent<BasicEnemy>();
        if (enemyCheck != null)
        {
            enemiesInRange.Add(enemyCheck.gameObject);
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (enemiesInRange.Contains(other.gameObject))
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }

    public void RemoveAndClean(GameObject gameObject)
    {
        enemiesInRange.Remove(gameObject);
        enemiesInRange.TrimExcess();
    }
}
