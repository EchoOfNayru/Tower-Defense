using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour {

    public float moveSpeed = 0.2f;

    private PlayerBase playerBase;
    private float timer;

	// Use this for initialization
	void Start () {
        timer = 0;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        timer += Time.deltaTime;
        Debug.Log(timer);

        if (timer >= 0.05)
        {
            transform.position -= transform.right * moveSpeed;
            timer = 0;
        }
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
    }
}
