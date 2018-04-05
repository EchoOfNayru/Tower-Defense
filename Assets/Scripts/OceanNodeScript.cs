using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanNodeScript : MonoBehaviour {

    public GameObject nodeUp;
    public GameObject nodeDown;
    public GameObject nodeLeft;
    public GameObject nodeRight;

    Ray downRay;
    Ray leftRay;

    // Use this for initialization
    void Start () {
        downRay.origin = transform.position;
        downRay.direction = Vector3.forward * -1;
        leftRay.origin = transform.position;
        leftRay.direction = Vector3.right * -1;

        RaycastHit hit;
        OceanNodeScript downScript;
        OceanNodeScript leftScript;

        if (Physics.Raycast(downRay, out hit))
        {
            nodeDown = hit.collider.gameObject;
            downScript = hit.collider.GetComponent<OceanNodeScript>();
            if (downScript != null)
            {
                downScript.nodeUp = gameObject;
            }
        }
        if (Physics.Raycast(leftRay, out hit))
        {
            nodeLeft = hit.collider.gameObject;
            leftScript = hit.collider.GetComponent<OceanNodeScript>();
            if (leftScript != null)
            {
                leftScript.nodeRight = gameObject;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(downRay.origin, downRay.direction, Color.green);

        
	}
}
