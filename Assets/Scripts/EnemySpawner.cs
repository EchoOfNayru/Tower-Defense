using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyToSpawn;
    public float timeToNextWave;

    private Vector3 spawnPosition;
    private Quaternion spawnRotaion;
    private float waveTimer;
    private bool isWave;
    private float enemyTimer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        waveTimer += Time.deltaTime;
        enemyTimer += Time.deltaTime;

        //if waveTimer is above time to next wave...
        if (waveTimer >= timeToNextWave)
        {
            //...then its currently a wave for 5 seconds...
            isWave = true;
            if (waveTimer >= timeToNextWave + 5)
            {
                //...after which is reset.
                isWave = false;
                waveTimer = 0;
            }
        }

        //if currently in a wave...
        if (isWave)
        {
            //...then spawn enemies every tick randomly along spawner
            if (enemyTimer >= 1)
            {
                enemyTimer = 0;
                GameObject spawnedThing = Instantiate(enemyToSpawn);
                spawnedThing.transform.position = new Vector3(spawnedThing.transform.position.x, spawnedThing.transform.position.y, spawnedThing.transform.position.z + Random.Range(-9f, 6f));
            }
        }

        Debug.Log(waveTimer);
	}
}
