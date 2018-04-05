using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGeneration : MonoBehaviour {

    public float xLength;
    public float yLength;
    public GameObject Node;


	// Use this for initialization
	void Start () {
        Vector3 startPos = transform.position;
        for (int i = 0; i < yLength; i++)
        {
            for (int j = 0; j < xLength; j++)
            {
                GameObject spawnedNode = Instantiate(Node);
                Vector3 spawnedPos = startPos + (Vector3.right * j * 2) + (Vector3.forward * i * 2);
                spawnedNode.transform.position = spawnedPos;
                Ray TestRay = 
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
