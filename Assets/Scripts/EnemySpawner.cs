using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyToSpawn;
    public float timeToNextWave;
    public Text waveTimerText;
    public int[] enemiesInWave;
    public int currentWave;
    public Button spawnNextWaveButton;
    public Text waveNumber;

    private Vector3 spawnPosition;
    private Quaternion spawnRotaion;
    private float waveTimer;
    private bool isWave;
    private float enemyTimer;
    private bool isFirstWave;
    private int currentWaveEnemiesSpawned;

	// Use this for initialization
	void Start () {
        isFirstWave = true;
        if (isFirstWave)
        {
            timeToNextWave = 120;
            isFirstWave = false;
        }
        currentWave = 0;
        waveNumber.text = "Wave " + (currentWave + 1);
        waveNumber.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        waveTimer += Time.deltaTime;
        float temp = timeToNextWave - waveTimer;
        if (temp <= 0)
        {
            temp += timeToNextWave + 5;
        }
        waveTimerText.text = "Time to next wave : " + Mathf.Round(temp);
        enemyTimer += Time.deltaTime;

        //if waveTimer is above time to next wave...
        if (waveTimer >= timeToNextWave)
        {
            //...then its currently a wave for 5 seconds...
            isWave = true;
            spawnNextWaveButton.interactable = false;
            if (waveTimer >= timeToNextWave + 5)
            {
                //...after which is reset.
                isWave = false;
                waveTimer = 0;
                currentWave++;
                waveNumber.text = "Wave " + (currentWave + 1);
                currentWaveEnemiesSpawned = 0;
                spawnNextWaveButton.interactable = true;
            }
        }

        //if currently in a wave...
        if (isWave)
        {
            //...then spawn enemies every tick randomly along spawner
            if (enemyTimer >= 0.2f && currentWaveEnemiesSpawned < enemiesInWave[currentWave])
            {
                enemyTimer = 0;
                GameObject spawnedThing = Instantiate(enemyToSpawn);
                spawnedThing.transform.position = new Vector3(spawnedThing.transform.position.x, spawnedThing.transform.position.y, spawnedThing.transform.position.z + Random.Range(-9f, 6f));
                currentWaveEnemiesSpawned++;
            }

            //...for X seconds display the wave number
            if (waveTimer >= timeToNextWave && waveTimer <= timeToNextWave + 2)
            {
                waveNumber.enabled = true;
            }
            else
            {
                waveNumber.enabled = false;
            }
        }

        if ((currentWave + 1) > enemiesInWave.Length)
        {
            timeToNextWave = 1000;
        }

        //Debug.Log(waveTimer);
        //Debug.Log(temp);
    }

    public void SpawnNextWaveOnClick()
    {
        timeToNextWave = 20;
        waveTimer = timeToNextWave - 0.02f;
    }
}
