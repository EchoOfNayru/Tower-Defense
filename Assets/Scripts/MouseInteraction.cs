using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteraction : MonoBehaviour {

    public GameObject wall;

    BasicEnemy enemyClicked;
    OceanNodeScript OceanNodeClicked;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    //Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

                    enemyClicked = hit.collider.GetComponent<BasicEnemy>();
                    if (enemyClicked != null)
                    {
                        Destroy(enemyClicked.gameObject);
                    }
                    OceanNodeClicked = hit.collider.GetComponent<OceanNodeScript>();
                    if (OceanNodeClicked != null)
                    {
                        Instantiate(wall, hit.collider.transform);
                    }
                }
            }  
        }

        enemyClicked = null;
    }
}
