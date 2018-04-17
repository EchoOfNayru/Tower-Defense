using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour {

    public float moveSpeed = 0.2f;
    public float startingHealth;

    PlayerBase playerBase;
    BulletScript bullet;
    float health;

	// Use this for initialization
	void Start () {
        health = startingHealth;
    }

    void Update()
    {
        transform.Translate(-transform.right * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        playerBase = other.GetComponent<PlayerBase>();
        if (playerBase != null)
        {
            playerBase.health--;
            playerBase.OnUpdateHealthUI();
            Destroy(gameObject);
        }

        bullet = other.GetComponent<BulletScript>();
        if (bullet != null)
        {
            health -= bullet.towerShotFrom.towerDamage;
            Destroy(bullet.gameObject);
            if (health <= 0)
            {
                bullet.towerShotFrom.RemoveAndClean(gameObject);
                Destroy(gameObject);
            }
        }
    }

    //have the enemy know where to go
        //having knowledge of the grid
            //grid has a clear path to the player base
            //knowing which nodes have a building
            //knowing if something is in front of the enemy
            //which is the shortest path
    

    //if somethign is in front move up or down
        //does up or down lead to the base
            

    //nodes with buildings are red
    //walkable nodes are blue
}
