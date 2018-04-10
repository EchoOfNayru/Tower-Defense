using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanNodeScript : MonoBehaviour {

    public GameObject nodeUp;
    public GameObject nodeDown;
    public GameObject nodeLeft;
    public GameObject nodeRight;
    public bool isBuilt;

    Ray downRay;
    Ray leftRay;

    // Use this for initialization
    void Start () {
        downRay.origin = transform.position;
        downRay.direction = Vector3.forward * -1;
        leftRay.origin = transform.position;
        leftRay.direction = Vector3.right * -1;
        isBuilt = false;

        RaycastHit hit;
        OceanNodeScript downScript;
        OceanNodeScript leftScript;

        if (Physics.Raycast(downRay, out hit))
        {
            
            downScript = hit.collider.GetComponent<OceanNodeScript>();
            if (downScript != null)
            {
                nodeDown = hit.collider.gameObject;
                downScript.nodeUp = gameObject;
            }
        }
        if (Physics.Raycast(leftRay, out hit))
        {
            
            leftScript = hit.collider.GetComponent<OceanNodeScript>();
            if (leftScript != null)
            {
                nodeLeft = hit.collider.gameObject;
                leftScript.nodeRight = gameObject;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
